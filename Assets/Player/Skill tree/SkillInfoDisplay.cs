using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillInfoDisplay : MonoBehaviour
{
    public GameCoordinator gameCoordinator;
    public Text coin;

    public Sprite Skill_Icon;
    public string Skill_Name;
    public string Skill_Effect;

    public Image Skill_Icon_Display;
    public TMP_Text Skill_Name_Display;
    public TMP_Text Skill_Effect_Display;

    public GameObject Tab1;
    public GameObject Tab2;
    public GameObject Tab3;

    // Start is called before the first frame update
    void Start()
    {
        gameCoordinator = GameObject.Find("Game Coordinator").GetComponent<GameCoordinator>();
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = gameCoordinator.coin.ToString();
        Skill_Icon_Display.sprite = Skill_Icon;
        Skill_Name_Display.text = Skill_Name;
        Skill_Effect_Display.text = Skill_Effect;
    }

    public void ShowTab1()
    {
        Tab1.SetActive(true);
        Tab2.SetActive(false);
        Tab3.SetActive(false);
    }
    public void ShowTab2()
    {
        Tab1.SetActive(false);
        Tab2.SetActive(true);
        Tab3.SetActive(false);
    }
    public void ShowTab3()
    {
        Tab1.SetActive(false);
        Tab2.SetActive(false);
        Tab3.SetActive(true);
    }
}
