using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBooster : MonoBehaviour
{
    public Transform effectPos;
    private bool z =false;
    public int Power_Booster = 1;
    public bool changeBooster = false;
    private Animator anim;
    private float Power_Booster_countdown = 8;
    private float x;
    private float y;
    public GameObject ReadyEffect;

    // boost status
    public float damage_bonus = 0;
    public float firespeed_bonus = 0;
    public float movement_bonus = 0;
    public int physical_recovery_boost = 0;
    public GameObject Soldier;
    public bool OnBooting = false;

    public GameObject Player_Health;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangePowerBooster();
        UseBooster();
        Ready();
    }
    void ChangePowerBooster()
    {
        //Change power booster;
        if (changeBooster )
        {
            x = 1;
            if (Power_Booster == 1)
            {
                anim.SetInteger("Anim", 1);
            }
            else if (Power_Booster == 2)
            {
                anim.SetInteger("Anim", 2);
            }
            else if (Power_Booster == 3)
            {
                anim.SetInteger("Anim", 3);
            }
        }
        if (x < 0)
        {
            anim.SetInteger("Anim", 0);
            changeBooster = false;
        }
        else
        {
            x -= Time.deltaTime;
        }
    }

    void UseBooster()
    {
        if (Input.GetButtonDown("Use Power Booter") & Power_Booster_countdown == 0)
        {
            OnBooting = true;
            switch (Power_Booster)
            {
                case 1:
                    if (OnBooting)
                    {
                        damage_bonus = 0.3f;
                        firespeed_bonus = 0.05f;
                    }
                    Invoke("Power_Booster_Finished", 8f);
                    Power_Booster_countdown = 30;
                    break;
                case 2:
                    if (OnBooting)
                    {
                        Instantiate(Soldier, transform.position, transform.rotation);
                    }
                    Invoke("Power_Booster_Finished", 8f);
                    Power_Booster_countdown = 27;
                    break;
                case 3:
                    if (OnBooting)
                    {
                        movement_bonus = 3.2f;
                    }
                    Invoke("Power_Booster_Finished", 8f);
                    Power_Booster_countdown = 35;
                    break;
            }
        }
        Count_Down_Power_Booster();
    }

    void Count_Down_Power_Booster()
    {
        if (Power_Booster_countdown > 0)
        {
            Power_Booster_countdown -= Time.deltaTime;
        }
        else if (Power_Booster_countdown < 0)
        {
            Power_Booster_countdown = 0;
        }
    }
    void Power_Booster_Finished()
    {
        OnBooting = false;
        damage_bonus = 0;
        firespeed_bonus = 0f;
        movement_bonus = 0;
    }

    // ready effect
    void Ready()
    {
        if (Power_Booster_countdown <= 0 & !z)
        {
            if (GetComponentInParent<Rigidbody2D>().velocity.y < -1)
            {
                y = Random.Range(1f, 2f);
            }
            else if(GetComponentInParent<Rigidbody2D>().velocity.y > 1)
            {
                y = Random.Range(-2f, -1f);
            }
            else
            {
                y = Random.Range(-1f, 1f);
            }
            z = true;
            GameObject a = Instantiate(ReadyEffect, effectPos.transform.position,transform.rotation);
            a.GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponentInParent<Player>().FacingR * Random.Range(1f, 2f), y * Random.Range(1f, 2f));
            Invoke("spawneffect", 0.05f);
        }
    }
    void spawneffect()
    {
        z = false;
    }
}
