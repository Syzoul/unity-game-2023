using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool Switched = false;
    public bool Auto = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Switched)
        {
            Invoke("ReturnSwitched", 1f);
            GetComponent<Animator>().SetInteger("Anim", 2);
        }
        else
        {
            GetComponent<Animator>().SetInteger("Anim", 1);
        }
        if (!Switched & !Auto)
        {
            if (GetComponent<Interacted>().interacted == true)
            {
                Switched = true;
                GetComponent<Interacted>().interacted = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !Switched & Auto)
        {
            Switched = true;
        }
    }
    void ReturnSwitched()
    {
        Switched = false;
    }
}
