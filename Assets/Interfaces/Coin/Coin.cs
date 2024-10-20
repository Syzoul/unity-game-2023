using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool move =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check();
        if(move)
        {
            GetComponent<Rigidbody2D>().position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.3f);
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Invoke("check", Random.Range(0.1f, 0.5f));
        }
    }

    void check()
    {
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            Invoke("movetoplayer", Random.Range(0.1f, 0.5f));
        }
    }
    void movetoplayer()
    {
        move = true;    
    }
}
