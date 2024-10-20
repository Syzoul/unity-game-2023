using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;
    private bool Callingup;
    private bool OnMoving = false;
    private bool OnTop;
    private bool OnBot;
    private bool carried = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CallElevator();
        MoveCage();
    }


    void CallElevator()
    {
        // check position
        if(objects[5].transform.position.y >= objects[2].transform.position.y)
        {
            OnTop = true;
            OnBot = false;
        }
        else if(objects[5].transform.position.y <= objects[4].transform.position.y)
        {
            OnBot = true;
            OnTop = false;
        }

        // call elevator
        if (objects[1].GetComponent<Switch>().Switched == true)
        {
            if (OnBot)
            {
                Callingup = true;
            }
        }
        if (objects[3].GetComponent<Switch>().Switched == true)
        {
            if (OnTop)
            {
                Callingup = false;
            }
        }

        if (objects[5].GetComponentInChildren<Switch>().Switched == true & !OnMoving)
        {
            Invoke("startcarring", 0.9f);
        }
        // carry
        if (carried == true & !OnMoving)
        {
            if (Callingup)
            {
                Callingup = false;
            }
            else
            {
                Callingup = true;
            }
        }
        
    }
    async void startcarring()
    {
        carried = true;
        await Task.Delay(10);
        carried = false;
    }

    void MoveCage()
    {
        if (Callingup)
        {
            if (OnBot)
            {
                objects[5].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.5f);
                OnMoving = true;
            }
            else
            {
                objects[5].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                objects[5].transform.position = objects[2].transform.position;
                OnMoving = false;
                carried = false;
            }
        }
        else

        {
            if (OnTop)
            {
                objects[5].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3.5f);
                OnMoving = true;
            }
            else
            {
                objects[5].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                objects[5].transform.position = objects[4].transform.position;
                OnMoving = false;
                carried = false;
            }
        }
    }
}
