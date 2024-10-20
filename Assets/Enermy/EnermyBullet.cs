using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBullet : MonoBehaviour
{
    public int Speed = 8;
    public bool Dealt_Damage = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Dealt_Damage==true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Dealt_Damage = true;
        }
        else if(collision.gameObject.CompareTag("Body_Player"))
        {
            collision.GetComponent<HealthPlayer>().Health -= GetComponent<Damage>().damage - collision.GetComponent<HealthPlayer>().damage_reduce;
            Dealt_Damage = true;
        }
    }
}
