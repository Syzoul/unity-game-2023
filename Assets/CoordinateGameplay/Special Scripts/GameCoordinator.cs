using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCoordinator : MonoBehaviour
{
    public GameObject StopMenu;
    public int coin;
    public Text CoinNumberOutPut;
    private bool col = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
        coin = PlayerPrefs.GetInt("Coin", 0);

        // move through
        Physics2D.IgnoreLayerCollision(11, 11, col);
        Physics2D.IgnoreLayerCollision(11, 6, col);
        Physics2D.IgnoreLayerCollision(7, 7, col);
        Physics2D.IgnoreLayerCollision(7, 12, col);
        Physics2D.IgnoreLayerCollision(7, 6, col);
        Physics2D.IgnoreLayerCollision(12, 12, col);
        Physics2D.IgnoreLayerCollision(6, 12, col);
        Physics2D.IgnoreLayerCollision(6, 6, col);
        Physics2D.IgnoreLayerCollision(9, 8, col);
        Physics2D.IgnoreLayerCollision(9, 7, col);
    }

    // Update is called once per frame
    void Update()
    {
        Update_Text();
        stop();
    }
    private void Update_Text()
    {
        CoinNumberOutPut.text = coin.ToString();
    }
    private void stop()
    {
        if (Input.GetButtonDown("Stop"))
        {
            if(StopMenu.activeSelf == false)
            {
                GameObject.Find("Player").GetComponent<Player>().DisablePlayer = true;
                StopMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                GameObject.Find("Player").GetComponent<Player>().DisablePlayer = false;
                StopMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void Resume()
    {
        GameObject.Find("Player").GetComponent<Player>().DisablePlayer = false;
        StopMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
