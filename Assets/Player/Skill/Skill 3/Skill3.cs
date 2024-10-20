using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    [SerializeField] private AudioSource ShootSound;

    public Transform FirePos;
    public GameObject[] Arrow;

    public bool readyshooting = false;
    public bool Shooted = false;
    public bool OnShoot = false;
    private float x;

    public GameObject Booster;
    // status
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
        if (!readyshooting && Input.GetAxis("Shoot") == 1)
        {
            ReadyShoot();
            OnShoot = true;
        }
        else if (readyshooting)
        {
            OnShoot = true;
            Shoot();
        }
        else if (Input.GetAxis("Shoot") == 0 && !readyshooting)
        {
            //anim.SetInteger("BowAnim", 1);
            OnShoot = false;
            x = 0;
        }
        GetComponentInParent<Player>().OnShooting = OnShoot;
    }
    void ReadyShoot()
    {

        if (Input.GetAxis("Shoot") == 1 & GetComponentInParent<Player>().OnRoll == false & GetComponentInParent<Player>().OnCrouch == false)
        {
            //anim.SetInteger("BowAnim", 2);
            x += Time.deltaTime;
            if (x >= 0.9f)
            {
                ready();
            }
        }
    }
    void Shoot()
    {
        if (Input.GetAxis("Shoot") == 0 & !Shooted & readyshooting & x != 0)
        {
            Shooted = true;
            //anim.SetInteger("BowAnim", 3);
            // Spawn Bullet
            GameObject bl = Instantiate(Arrow[1], FirePos.transform.position, transform.rotation);
            bl.GetComponent<Rigidbody2D>().velocity = new Vector2(24 * GetComponentInParent<Player>().FacingR, 0);
            ShootSound.Play();
            GetComponentInParent<Player>().DisablePlayer = true;
            Invoke("Finish", FireSpeed - FireSpeed_Bonus - Booster.GetComponent<PowerBooster>().firespeed_bonus);
        }
        // hold

    }

    void ready()
    {
        if (Input.GetAxis("Shoot") == 1)
        {
            readyshooting = true;
        }
    }
    void Finish()
    {
        GetComponentInParent<Player>().DisablePlayer = false;
        OnShoot = false;
        Shooted = false;
        readyshooting = false;
        x = 0;
    }
}
