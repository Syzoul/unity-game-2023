using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    public string nextmap;
    public float nextCheckPoint_x;
    public float nextCheckPoint_y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Interacted>().interacted)
        {
            PlayerPrefs.SetInt("Coin", GameObject.Find("Game Coordinator").GetComponent<GameCoordinator>().coin);
            PlayerPrefs.SetString("Map", nextmap);
            PlayerPrefs.SetFloat("Check point x", nextCheckPoint_x);
            PlayerPrefs.SetFloat("Check point y", nextCheckPoint_y);
            SceneManager.LoadScene(nextmap);
            GetComponent<Interacted>().interacted = false;
        }
    }
}
