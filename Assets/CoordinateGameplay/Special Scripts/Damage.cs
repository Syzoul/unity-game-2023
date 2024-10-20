using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int Base_Damage = 1;
    public int Damage_Bonus;
    public int damage;
    public int Boost_Damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = Base_Damage + Damage_Bonus + Boost_Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
