using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    [SerializeField] private AudioSource ShootSound;
    public Transform FirePos;
    public GameObject[] Bullet;
    public bool OnShoot = false;
    public bool Shooted = false;
    private bool delayShooting = false;

    public GameObject Booster;
    // Status 
    public float FireSpeed;
    // Boost
    public int Damage_Bonus;
    public float FireSpeed_Bonus;

    // Start is called before the first frame update
    void Start()
    {
        ShootSound.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    // Update is called once per frame
    void Update()
    {
        Fire();

    }
    void Fire()
    {
        GetComponentInParent<Player>().OnShooting = OnShoot;


        if (GetComponentInParent<Player>().OnRoll == true)
        {
            delayShooting = false;
            OnShoot = false;
        }


        if (Input.GetAxis("Shoot") == 0)
        {
            OnShoot = false;
        }

        if (Input.GetAxis("Shoot") == 1 & !delayShooting && !Shooted & GetComponentInParent<Player>().OnRoll == false & GetComponentInParent<Player>().OnCrouch == false)
        {

            Invoke("x", 0.05f);
            // anim.SetInteger("GunAnim", 2);
            // Spawn Bullet
            GameObject bl = Instantiate(Bullet[1], FirePos.transform.position, transform.rotation);
            bl.GetComponent<Rigidbody2D>().velocity = new Vector2(13 * GetComponentInParent<Player>().FacingR, Random.Range(-0.3f, 0.5f));
            bl.GetComponent<Damage>().Boost_Damage = Mathf.RoundToInt( (bl.GetComponent<Damage>().Damage_Bonus + bl.GetComponent<Damage>().Base_Damage) * Booster.GetComponent<PowerBooster>().damage_bonus);
            Shooted = true;
            ShootSound.Play();
            Invoke("delayshooting", FireSpeed - FireSpeed_Bonus - Booster.GetComponent<PowerBooster>().firespeed_bonus);

            OnShoot = true;
        }

        // else if (Input.GetAxis("Shoot") == 1 && delayShooting && Shooted && GetComponentInParent<Player>().OnSpecialMovement == false)
        // {
        //   anim.SetInteger("GunAnim", 3);
        // }
        // else if (!OnShoot)
        // {
        // anim.SetInteger("GunAnim", 1);
        // }

    }


    void delayshooting()
    {
        delayShooting = false;
        Shooted = false;
        if (Input.GetAxis("Shoot") == 1)
        {
            OnShoot = true;
        }
        else
        {
            OnShoot = false;
        }
    }

    void x()
    {
        delayShooting = true;
    }

    // Shake effect

    
}
