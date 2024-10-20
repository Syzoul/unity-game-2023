using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject SettingMenu;
    public GameObject Mainmenu;
    public Slider Music;
    public Slider SFX;
    public GameObject msb;
    [SerializeField] private AudioSource ClickSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        msb.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
        ClickSound.volume = PlayerPrefs.GetFloat("SFXVolume");
    }
    public void PlayGame()
    {

        ClickSound.Play();
        SceneManager.LoadScene(PlayerPrefs.GetString("Check map","Map 1"));
    }
    public void Setting()
    {
        ClickSound.Play();
        SettingMenu.SetActive(true);
        Mainmenu.SetActive(false);
        Music.value = PlayerPrefs.GetFloat("MusicVolume", Music.maxValue);
        SFX.value = PlayerPrefs.GetFloat("SFXVolume", SFX.maxValue);
    }
    public void ExitGame()
    {
        ClickSound.Play();
        Application.Quit();
    }
    public void Back()
    {
        ClickSound.Play();
        SettingMenu.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void Save()
    {
        ClickSound.Play();
        PlayerPrefs.SetFloat("MusicVolume", Music.value);
        PlayerPrefs.SetFloat("SFXVolume", SFX.value);
    }
}
