using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Check_Point : MonoBehaviour
{
    public GameObject SaveText;
    public GameObject SaveTextPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(SaveText, SaveTextPos.transform);
            PlayerPrefs.SetInt("Coin", GameObject.Find("Game Coordinator").GetComponent<GameCoordinator>().coin);
            PlayerPrefs.SetFloat("Check point x", transform.position.x);
            PlayerPrefs.SetFloat("Check point y", transform.position.y);
            PlayerPrefs.SetString("Check map", SceneManager.GetActiveScene().name);
        }
    }
}
