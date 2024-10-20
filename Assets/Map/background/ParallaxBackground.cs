using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float movex;
    public float movey;
    public GameObject CameraPos;
    // Start is called before the first frame update
    void Start()
    {
        CameraPos = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(CameraPos.transform.position.x * movex, CameraPos.transform.position.y * movey);
    }
}
