using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;




public class ChangeGlobalLight2D : MonoBehaviour
{
    public LayerMask LayerDetect;
    public Light2D Global_light;
    public float MaxValue = 1;
    public float MinValue ;
    public int FacingR = 1;
    private float h;
    private float S;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D check = Physics2D.Raycast(transform.position, Vector2.right *FacingR, 5.2f, LayerDetect);
        Debug.DrawRay(transform.position, Vector2.right * 5.2f * FacingR, Color.green);
        if (check.collider != null )
        {
            if (check.collider.gameObject.CompareTag("Player"))
            {
                if(Mathf.Abs(transform.position.x - check.collider.gameObject.transform.position.x) >= 5)
                {
                    x = 5;
                }
                else if(Mathf.Abs(transform.position.x - check.collider.gameObject.transform.position.x) <= 1)
                {
                    x = 1;
                }
                else
                {
                    x = Mathf.Abs(transform.position.x - check.collider.gameObject.transform.position.x);
                }
                y = (x - 1) / 4;
                S = y * (MaxValue - MinValue);
                h = MaxValue - S;
                Global_light.intensity = h;
            }
        }
    }
}
