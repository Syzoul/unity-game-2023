using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        setanim();
    }
    void setanim()
    {
        if (Player.GetComponentInChildren<HealthPlayer>().Health>=900)
        {
            anim.SetInteger("Anim", 0);
        }
        else if(Player.GetComponentInChildren<HealthPlayer>().Health < 900 & Player.GetComponentInChildren<HealthPlayer>().Health >= 650)
        {
            anim.SetInteger("Anim", 1);
        }
        else if (Player.GetComponentInChildren<HealthPlayer>().Health < 600 & Player.GetComponentInChildren<HealthPlayer>().Health >= 300)
        {
            anim.SetInteger("Anim", 2);
        }
        else if (Player.GetComponentInChildren<HealthPlayer>().Health < 300 )
        {
            anim.SetInteger("Anim", 3);
        }
    }
}
