using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject des;
    public float TimeDes;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
  
        Invoke("DestroyObject", TimeDes);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enermy"))
        {
            Instantiate(des, transform.position,Quaternion.Euler(0,0,Random.Range(-90,90)));
            if(collision.gameObject.CompareTag("Enermy"))
            {
                collision.gameObject.GetComponent<HealthEnermy>().Health -= GetComponent<Damage>().damage;
            }
            DestroyObject();
        }
    }
}
