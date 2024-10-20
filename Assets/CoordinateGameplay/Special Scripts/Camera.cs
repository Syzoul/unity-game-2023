using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public bool disableCamera = false;
    public bool ShakeScreen = false;
    public float ShakeAmount=2f;
    public GameObject Player;
    private Vector3 offset = new Vector3(0, 0.6f, -10);
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!disableCamera)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + offset, ref velocity, 0.2f);
        }
        if(ShakeScreen)
        {
            StartCoroutine(Shaking());
        }

    }
    IEnumerator Shaking()
    {
        Vector3 startpos = transform.position;
        float time = 0f;
        while (time < 0.2f)
        {
            time += Time.deltaTime;
            transform.position = startpos + Random.insideUnitSphere*ShakeAmount* Time.deltaTime;
            yield return null;
        }
        transform.position = startpos;
    }
}
