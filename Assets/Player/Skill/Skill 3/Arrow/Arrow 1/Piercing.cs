using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piercing : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            DestroyObject();
        }
        if (collision.gameObject.CompareTag("Enermy"))
        {
            collision.gameObject.GetComponent<HealthEnermy>().Health -= GetComponent<Damage>().damage;
        }
    }
}
