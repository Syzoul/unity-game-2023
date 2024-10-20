using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Coordinate : MonoBehaviour
{
    public Player player;
    public int Skill_Num = 1;

    public GameObject[] Skill;

    public GameObject powerBooster;

    // boost status


    private bool changeH =false;
    private bool changeV = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Change_Weapons();
    }


    void Change_Weapons()
    {
            //Show main weapon

        switch (Skill_Num)
                {
                    case 1:
                        for (int i = 1; i <= 3; i++)
                        {
                            if (i == Skill_Num)
                            {
                            Skill[i].SetActive(true);
                            }
                            else { Skill[i].SetActive(false); }

                        }
                        break;
                    case 2:
                        for (int i = 1; i <= 3; i++)
                        {
                            if (i == Skill_Num)
                            {
                                Skill[i].SetActive(true);
                            }
                            else { Skill[i].SetActive(false); }
                        }

                        break;
                    case 3:
                        for (int i = 1; i <= 3; i++)
                        {
                            if (i == Skill_Num)
                            {
                                Skill[i].SetActive(true);
                            }
                            else { Skill[i].SetActive(false); }
                        }

                        break;              
                }
        
            //Change main weapon
        if (Input.GetAxisRaw("Change Skill 2") == 1 & !changeH )
            {
                changeH = true;
                powerBooster.GetComponent<PowerBooster>().changeBooster = true;
                Skill_Num = 2;
                powerBooster.GetComponent<PowerBooster>().Power_Booster = Skill_Num;
            }
        if(Input.GetAxisRaw("Change Skill 1 and 3") ==1 & !changeV)
        {
            changeV = true;
            powerBooster.GetComponent<PowerBooster>().changeBooster = true;
            Skill_Num = 3;
            powerBooster.GetComponent<PowerBooster>().Power_Booster = Skill_Num;
        }
        else if(Input.GetAxisRaw("Change Skill 1 and 3") ==-1 & !changeV)
        {
            changeV = true;
            powerBooster.GetComponent<PowerBooster>().changeBooster = true;
            Skill_Num = 1;
            powerBooster.GetComponent<PowerBooster>().Power_Booster = Skill_Num;
        }
        //Return changeV and changeH
        if(Input.GetAxisRaw("Change Skill 1 and 3") ==0)
        {
            changeH = false;
        }
        else if (Input.GetAxisRaw("Change Skill 2") == 0)
        {
            changeV = false;
        }
        if(Input.GetAxisRaw("Change Skill 2") == 0 & Input.GetAxisRaw("Change Skill 1 and 3") == 0)
        {
            powerBooster.GetComponent<PowerBooster>().changeBooster = false;
        }

    }
}
