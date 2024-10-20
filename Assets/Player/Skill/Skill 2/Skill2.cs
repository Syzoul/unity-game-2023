using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Skill2 : MonoBehaviour
{
    [SerializeField] private AudioSource ShootSound;


    public Transform FirePos;
    public GameObject[] Bullet;
    public bool OnShoot = false;

    public GameObject Booster;
    // Status 
    public float FireSpeed;
    // Boost
    public int Damage_Bonus;
    public float FireSpeed_Bonus;

    // Start is called before the first frame update
    void Start()
    {
        ShootSound.volume = PlayerPrefs.GetFloat("SFXVolume");

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    async void Fire()
    {
        GetComponentInParent<Player>().OnShooting = OnShoot;

        if (GetComponentInParent<Player>().OnRoll == true)
        {
            OnShoot = false;
        }
        if (Input.GetButtonDown("Attack 2") & !OnShoot & GetComponentInParent<Player>().OnRoll == false & GetComponentInParent<Player>().OnCrouch == false)
        {
            OnShoot = true;
            await Task.Delay(200);
            if (OnShoot)
            {
                GetComponentInParent<Player>().DisablePlayer = true;
                // spawn 5 bullet
                GameObject bl1 = Instantiate(Bullet[1], FirePos.transform.position, transform.rotation);
                bl1.GetComponent<Rigidbody2D>().velocity = new Vector2(20 * GetComponentInParent<Player>().FacingR, Random.Range(5f, 6f));
                bl1.GetComponent<Damage>().Boost_Damage = Mathf.RoundToInt((bl1.GetComponent<Damage>().Damage_Bonus + bl1.GetComponent<Damage>().Base_Damage) * Booster.GetComponent<PowerBooster>().damage_bonus);
                GameObject bl2 = Instantiate(Bullet[1], FirePos.transform.position, transform.rotation);
                bl2.GetComponent<Rigidbody2D>().velocity = new Vector2(20 * GetComponentInParent<Player>().FacingR, Random.Range(2f, 3f));
                bl2.GetComponent<Damage>().Boost_Damage = Mathf.RoundToInt((bl2.GetComponent<Damage>().Damage_Bonus + bl2.GetComponent<Damage>().Base_Damage) * Booster.GetComponent<PowerBooster>().damage_bonus);
                GameObject bl3 = Instantiate(Bullet[1], FirePos.transform.position, transform.rotation);
                bl3.GetComponent<Rigidbody2D>().velocity = new Vector2(20 * GetComponentInParent<Player>().FacingR, 0);
                bl3.GetComponent<Damage>().Boost_Damage = Mathf.RoundToInt((bl3.GetComponent<Damage>().Damage_Bonus + bl3.GetComponent<Damage>().Base_Damage) * Booster.GetComponent<PowerBooster>().damage_bonus);
                GameObject bl4 = Instantiate(Bullet[1], FirePos.transform.position, transform.rotation);
                bl4.GetComponent<Rigidbody2D>().velocity = new Vector2(20 * GetComponentInParent<Player>().FacingR, Random.Range(-2f, -3f));
                bl4.GetComponent<Damage>().Boost_Damage = Mathf.RoundToInt((bl4.GetComponent<Damage>().Damage_Bonus + bl4.GetComponent<Damage>().Base_Damage) * Booster.GetComponent<PowerBooster>().damage_bonus);
                GameObject bl5 = Instantiate(Bullet[1], FirePos.transform.position, transform.rotation);
                bl5.GetComponent<Rigidbody2D>().velocity = new Vector2(20 * GetComponentInParent<Player>().FacingR, Random.Range(-5f, -6f));
                bl5.GetComponent<Damage>().Boost_Damage = Mathf.RoundToInt((bl5.GetComponent<Damage>().Damage_Bonus + bl5.GetComponent<Damage>().Base_Damage) * Booster.GetComponent<PowerBooster>().damage_bonus);
                ShootSound.Play();
                Invoke("delayshooting", FireSpeed - FireSpeed_Bonus - Booster.GetComponent<PowerBooster>().firespeed_bonus);
            }
        }
    }


    void delayshooting()
    {
        OnShoot = false;
        GetComponentInParent<Player>().DisablePlayer = false;
    }
}
