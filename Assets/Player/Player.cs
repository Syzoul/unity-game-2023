using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    public GameObject gamecoordinator;
    public GameObject ReadyInteractive ;

    public GameObject InteractiveObject;

    //sound effect
    public AudioSource SoundEffect;
    public AudioClip CollectCoinSound;
    public AudioClip JumpSound;
    public AudioClip RollSound;

    // Player status
    public float PlayerSpeed;
    public float JumpPower;

    public float countdownDash;
    public float movex;
    private int x;
    private Rigidbody2D Rig2d;
    public LayerMask layer;
    public int FacingR = 1;
    public float TotalMovementSpeed;

    public bool DisablePlayer = false;
    public bool Dead = false;
    public Animator anim;

    public int Skill_Num;

    public bool OnRoll = false;
    public bool OnJump ;
    public int phaseJump = 1;
    public bool OnGround;
    public bool OnMoveX;
    public bool OnIdle;
    public bool OnCrouch;
    public bool OnShooting;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(PlayerPrefs.GetFloat("Check point x"), PlayerPrefs.GetFloat("Check point y"));
        SoundEffect.volume = PlayerPrefs.GetFloat("SFXVolume");
        Rig2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Skill_Num = GetComponentInChildren<Weapons_Coordinate>().Skill_Num;
        if (!DisablePlayer & !Dead)
        {
            Playermovement();
        }
        Flip();
        Animate();
    }


    async void Playermovement()
    {
        if (!OnRoll & !OnMoveX & OnGround)
        {
            OnIdle = true;
        }
        else { OnIdle = false; }




        if (OnRoll)
        {
            OnMoveX = false;
        }
        else
        {
            if (movex > 0.3f || movex < -0.3f)
            {
                OnMoveX = true;
            }
            else { OnMoveX = false; }

        }
        //dash
        if(countdownDash < 4)
        {
            countdownDash += Time.deltaTime;
        }
        else
        {
            countdownDash = 4;
        }
        if (Input.GetButtonDown("Roll") & !OnRoll & !OnCrouch )
        {
            OnRoll = true;
            if (countdownDash >= 3f)
            {
                Rig2d.velocity = new Vector2(6 * FacingR * (countdownDash / 3), 0);
                Rig2d.gravityScale = 0;
            }
            else
            {
                Rig2d.velocity = new Vector2(6 * FacingR * (countdownDash / 3), Rig2d.velocity.y);
            }
            countdownDash = 0;
            SoundEffect.clip = RollSound;
            SoundEffect.Play();
            await Task.Delay(600);
            Rig2d.gravityScale = 2;
            OnRoll = false;
        }

        if (OnGround)
        {
            OnJump = false;
            phaseJump = 1;
        }

        //jump
        if (Input.GetButtonDown("Jump") & !OnCrouch)
        {
            if (OnGround & !OnJump  & phaseJump ==1)
            {
                phaseJump = 2; 
                OnJump = true;
                Rig2d.velocity = new Vector2(Rig2d.velocity.x, JumpPower);
                SoundEffect.clip = JumpSound;
                SoundEffect.Play();
            }
            if (!OnGround & phaseJump ==2 & OnJump)
            {
                phaseJump = 0;
                OnJump = true;
                Rig2d.velocity = new Vector2(Rig2d.velocity.x, JumpPower);
                SoundEffect.clip = JumpSound;
                SoundEffect.Play();
            }
        }

        // move
        TotalMovementSpeed = x * (PlayerSpeed + GetComponentInChildren<PowerBooster>().movement_bonus) ;
        if (!OnCrouch & !OnRoll)
        {
            if (OnShooting == false )
            {
                movex = Input.GetAxisRaw("Horizontal");
                if (movex != 0)
                {
                    if (movex > 0.3f)
                    { x = 1; }
                    else if (movex < -0.3f)
                    { x = -1; }
                    else { x = 0; }
                }
                else { x = 0; }
            }
            else
            {
                x = 0;
                movex = 0;

            }
            Rig2d.velocity = new Vector2(TotalMovementSpeed, Rig2d.velocity.y);
        }
        /*else
        {
            if (!OnRoll)
            {
                Rig2d.velocity = new Vector2(0, Rig2d.velocity.y);
            }
        }*/

        //crouch
        if (Input.GetAxisRaw("Crouch") > 0.6f & OnGround)
        {
            OnCrouch = true;
        }
        else if (Input.GetAxisRaw("Crouch") <= 0)
        {
            OnCrouch = false;
        }
    }

    void Flip()
    {
            if (movex > 0)
            {
                FacingR = 1;
            }
            else if (movex < 0)
            {
                FacingR = -1;
            }
            if (FacingR == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else { transform.rotation = Quaternion.Euler(0, 180, 0); }

    }    
    
    //animate
    void Animate()
    {
        if (!OnCrouch & !Dead)
        {
            // walk
            if (OnMoveX & !OnJump & OnGround /*& Rig2d.velocity.y < 0.0001 & Rig2d.velocity.y > -0.0001*/ & OnMoveX)
            {
                if(TotalMovementSpeed >= 4.5f || TotalMovementSpeed <= -4.5f)
                {
                    anim.SetInteger("PlayerAnim", 3);
                }
                else
                {
                    anim.SetInteger("PlayerAnim", 2);
                }
            }
            // jump
            else if (!OnGround & !OnRoll & !OnShooting)
            {
                if (Rig2d.velocity.y >= 0)
                {
                    anim.SetInteger("PlayerAnim", 4);
                }
                else
                {
                    anim.SetInteger("PlayerAnim", 5);
                }
            }
            // roll
            else if (OnRoll & !OnCrouch)
            {
                anim.SetInteger("PlayerAnim", 6);
            }
            // idle
            else if (OnIdle & !OnShooting & OnGround /*& Rig2d.velocity.y < 0.0001 & Rig2d.velocity.y > -0.0001*/)
            {
                anim.SetInteger("PlayerAnim", 1);
            }
            // attack
            else if (OnShooting)
            {
                switch (Skill_Num)
                {
                    case 1:
                        anim.SetInteger("PlayerAnim", 8);
                        break;
                    case 2:
                        anim.SetInteger("PlayerAnim", 9);
                        break;
                    case 3:
                        if (GetComponentInChildren<Skill3>().Shooted == true)
                        {
                            anim.SetInteger("PlayerAnim", 13);
                        }
                        else
                        {
                            anim.SetInteger("PlayerAnim", 10);
                        }
                        break;
                }
            }
        }
        // crouch
        else if (OnCrouch & !Dead)
        {
            anim.SetInteger("PlayerAnim", 7);
        }
        // dead
        else
        {
            Rig2d.gravityScale = 0;
            Rig2d.velocity = new Vector2(0,0);
            anim.SetInteger("PlayerAnim", 12);
        }
        if (transform.position.y <= -500)
        {
            GetComponentInChildren<HealthPlayer>().Health = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }

        // check and interact with interactive object
        if (collision.gameObject.CompareTag("Interactive_Object"))
        {
            ReadyInteractive.SetActive(true);
            InteractiveObject = collision.gameObject;
            if (Input.GetButtonDown("Interact"))
            {
                InteractiveObject.GetComponent<Interacted>().interacted = true;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gamecoordinator.GetComponent<GameCoordinator>().coin += 1;
            SoundEffect.clip = CollectCoinSound;
            SoundEffect.Play();
        }

        // check and interact with interactive object
        if (collision.gameObject.CompareTag("Interactive_Object"))
        {
            ReadyInteractive.SetActive(true);
            InteractiveObject = collision.gameObject;
            if (Input.GetButtonDown("Interact"))
            {
                InteractiveObject.GetComponent<Interacted>().interacted = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
        else
        {
            ReadyInteractive.SetActive(false);
        }
        // check and interact with interactive object
        if (collision.gameObject.CompareTag("Interactive_Object"))
        {
            ReadyInteractive.SetActive(false);
            InteractiveObject = null;
        }
    }

}
