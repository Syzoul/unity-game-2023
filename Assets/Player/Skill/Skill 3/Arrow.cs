using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int x;
    public GameObject Explode;
    public GameObject Piercing;
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
        if (collision.gameObject.CompareTag("Enermy"))
        {
            Instantiate(Explode, transform.position, transform.rotation);
            GameObject piercing = Instantiate(Piercing, transform.position, transform.rotation);
            if(GetComponent<Rigidbody2D>().velocity.x>0)
            {
                x = 1;
            }
            else
            {
                x = -1;
            }
            piercing.GetComponent<Rigidbody2D>().velocity = new Vector2(26 * x, 0);
            DestroyObject();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(Explode, transform.position, transform.rotation) ;
            DestroyObject();
        }
    }

}
