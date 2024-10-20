using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Firecamp : MonoBehaviour
{
    public GameObject SaveText;
    public GameObject SaveTextPos;
    public GameObject SkillTreePanle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        openskilltree();
    }
    void openskilltree()
    {
        if (GetComponent<Interacted>().interacted)
        {
            Time.timeScale = 0;
            SkillTreePanle.SetActive(true);
            GameObject.Find("Player").GetComponent<Player>().DisablePlayer = true;
        }
        else
        {
            Time.timeScale = 1;
            SkillTreePanle.SetActive(false);
        }
    }
    public void Back()
    {
        GetComponent<Interacted>().interacted = false;
        GameObject.Find("Player").GetComponent<Player>().DisablePlayer = false;
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

            PlayerPrefs.SetFloat("Revive point x", transform.position.x);
            PlayerPrefs.SetFloat("Revive point y", transform.position.y);
            PlayerPrefs.SetString("Revive map", SceneManager.GetActiveScene().name);
        }
    }
}
