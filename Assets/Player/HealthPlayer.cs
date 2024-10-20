using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    private bool healed = false;
    public int Health = 1000;
    public int damage_reduce;

    private bool fallfromhighplace = false;
    private bool dead = false;
     // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Healing();
        if (Health<=0)
        {
            PlayerPrefs.SetInt("Coin", 0);
            GetComponentInParent<Player>().Dead = true;
            PlayerPrefs.SetFloat("Check point x", PlayerPrefs.GetFloat("Revive point x", 0));
            PlayerPrefs.SetFloat("Check point y", PlayerPrefs.GetFloat("Revive point y", 0));
            PlayerPrefs.SetString("Check map", PlayerPrefs.GetString("Revive map"));
            Invoke("respawn", 1.5f);
        }
        if (GetComponentInParent<Rigidbody2D>().velocity.y < -20)
        {
            fallfromhighplace = true;
            if (GetComponentInParent<Rigidbody2D>().velocity.y < -30)
            {
                dead = true;
            }
            else
            {
                dead = false;
            }
        }
        else
        {
            Invoke("backtoground", 0.1f);
        }
        if (fallfromhighplace)
        {
            if (dead)
            {
                if (GetComponentInParent<Player>().OnGround == true)
                {
                    Health = -10;
                    fallfromhighplace = false;
                }
            }
            else
            {
                if (GetComponentInParent<Player>().OnGround == true)
                {
                    Health -= 500;
                    fallfromhighplace = false;
                }
            }
        }
    }
    void backtoground()
    {
        fallfromhighplace = false;
    }
    void Healing()
    {
        if (!healed)
        {
            healed = true;
            Invoke("heal", 0.03f);
        }
    }
    void heal()
    {
        if (Health >= 1000)
        {
            Health = 1000;
        }
        else if (Health < 1000)
        {
            Health += 1;
        }
        healed = false;
    }

    // respawn
    void respawn()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Revive map"));
    }

}
