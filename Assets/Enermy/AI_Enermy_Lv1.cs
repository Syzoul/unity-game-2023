using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enermy_Lv1 : MonoBehaviour
{
    public Transform Eyes;
    public Transform JumpPos1;
    public Transform JumpPos2;
    public int MovementSpeed;
    private Rigidbody2D Rig2d;
    private Animator Anim;
    public GameObject Player;
    public int FacingR = 1;
    public LayerMask LayerDetect;
    public bool OnCamera = false;

    public bool OnGround;
    public bool PurchasePlayer = false;
    public bool DisableEnermy = false;
    public bool OnAttack = false;

    public float AttackRange;

    // Start is called before the first frame update
    void Start()
    {

        Rig2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnCamera)
        {
            GetInAttackRange();
            DetectPlayer();
            Flip();
        }

        Jump();
        if (!DisableEnermy)
        {
            if (PurchasePlayer & !OnAttack & (((transform.position.x - Player.transform.position.x) * (transform.position.x - Player.transform.position.x)) > 0.5f))
            {
                if ((transform.position.x - Player.transform.position.x) > 0)
                {
                    FacingR = -1;
                }
                else { FacingR = 1; }
                Rig2d.velocity = new Vector2(MovementSpeed * FacingR, Rig2d.velocity.y);
                Anim.SetInteger("EnermyAnim", 2);
            }
            else
            {
                Rig2d.velocity = new Vector2(0, Rig2d.velocity.y);
                Anim.SetInteger("EnermyAnim", 1);
            }
        }

    }
    void Flip()
    {
        if (FacingR == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else { transform.rotation = Quaternion.Euler(0, 180, 0); }
    }

    // detect player
    void DetectPlayer()
    {
        Player = GameObject.Find("Player");
        RaycastHit2D Look = Physics2D.Raycast(Eyes.transform.position, Vector2.right * FacingR, 20f, LayerDetect);
        Debug.DrawRay(Eyes.transform.position, Vector2.right * 20f * FacingR, Color.red);
        RaycastHit2D Back = Physics2D.Raycast(Eyes.transform.position, Vector2.left * FacingR, 6f, LayerDetect);
        Debug.DrawRay(Eyes.transform.position, Vector2.left * 6f * FacingR, Color.green);
        if ((Look.collider != null && Look.collider.gameObject.CompareTag("Player")) || (Back.collider != null && Back.collider.gameObject.CompareTag("Player")))
        {
            PurchasePlayer = true;
        }
    }

    //  determine attack range
    void GetInAttackRange()
    {
        RaycastHit2D detectattack = Physics2D.Raycast(transform.position, Vector2.right * FacingR, AttackRange, LayerDetect);
        Debug.DrawRay(transform.position, Vector2.right * FacingR * AttackRange, Color.black);
        if (detectattack.collider != null && detectattack.collider.CompareTag("Player"))
        {
            OnAttack = true;
        }
        else
        {
            OnAttack = false;
        }
    }

    // Jump 
    void Jump()
    {
        RaycastHit2D Jumppos1 = Physics2D.Raycast(JumpPos1.transform.position, Vector2.right * FacingR, 0.5f, LayerDetect);
        Debug.DrawRay(JumpPos1.transform.position, Vector2.right * 0.5f * FacingR, Color.green);
        RaycastHit2D Jumppos2 = Physics2D.Raycast(JumpPos2.transform.position, Vector2.right * FacingR, 0.5f, LayerDetect);
        Debug.DrawRay(JumpPos2.transform.position, Vector2.right * 0.5f * FacingR, Color.green);

        if (Jumppos1.collider == null && Jumppos2.collider != null && OnGround)
        {
            if (Jumppos2.collider.gameObject.CompareTag("Ground"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 7);
            }
        }
    }

    private void OnBecameInvisible()
    {
        OnCamera = false;
    }
    private void OnBecameVisible()
    {
        OnCamera = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
}
