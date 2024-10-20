using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject maincamera;

    private bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
        maincamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        maincamera.GetComponent<Camera>().ShakeScreen = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enermy") & !damaged)
        {
            collision.gameObject.GetComponent<HealthEnermy>().Health -= GetComponent<Damage>().damage;
        }
    }
    private void OnDestroy()
    {
        maincamera.GetComponent<Camera>().ShakeScreen = false;

    }
}
