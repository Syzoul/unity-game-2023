using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Weapon : MonoBehaviour
{
    public int Special_Weapon_Num;
    public bool BeUsed =false;
    public GameObject Special_Weapon_Pos;
    // Start is called before the first frame update
    void Start()
    {
        Special_Weapon_Pos = GameObject.Find("Special Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        if(BeUsed)
        {
            GetComponent<Rigidbody2D>().transform.position = Special_Weapon_Pos.transform.position;
            
        }
    }
}
