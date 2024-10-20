using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    public Sprite Skill_Icon;
    public string Skill_Name;
    public string Skill_Effect;
    public SkillInfoDisplay skillInfoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Skill_Icon = GetComponent<Image>().sprite;
        skillInfoDisplay = GetComponentInParent<SkillInfoDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // show
    public void Pressed()
    {
        skillInfoDisplay.Skill_Icon = Skill_Icon;
        skillInfoDisplay.Skill_Name = Skill_Name;
        skillInfoDisplay.Skill_Effect = Skill_Effect;
    }
}
