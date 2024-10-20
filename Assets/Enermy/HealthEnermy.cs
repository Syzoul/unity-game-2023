using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnermy : MonoBehaviour
{
    public int Health;
    public int CoinDrop;
    public GameObject Coin;
    public GameObject EnermyDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0)
        {
            Instantiate(EnermyDeath, transform.position, transform.rotation);
            for(int i = 1; i <= Random.Range(1, CoinDrop); i++)
            {
                GameObject coin = Instantiate(Coin, transform.position, transform.rotation);
                coin.GetComponent<Rigidbody2D>().velocity = new Vector2(3 * Random.Range(-1.5f,1.5f), -0.01f);
            }
            Destroy(gameObject);
        }
    }
}
