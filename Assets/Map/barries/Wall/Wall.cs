using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wall;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Interacted>().interacted == true)
        {
            anim.SetInteger("Anim", 1);
            wall.SetActive(false);
        }
        else
        {
            anim.SetInteger("Anim", 0);
        }
    }
}
