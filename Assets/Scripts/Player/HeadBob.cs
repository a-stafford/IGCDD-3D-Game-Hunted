using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{

    private float timer = 0.0f;
    public float maxSpeed = 0.2f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float runBobbingSpeed = 0.25f;
    public float crouchBobbingSpeed = 0.18f;

    public float midpoint = 0.577f;
    public float crouchMidpoint = 0.19f;

    void Update()
    {

        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(PlayerMovment.Running == true && PlayerMovment.Grounded == true)
        {
            bobbingSpeed = runBobbingSpeed;
        }
        else
        {
            bobbingSpeed = maxSpeed;
     
        }


        Vector3 cSharpConversion = transform.localPosition;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        

        if(PlayerMovment.Crouching == true)
        {
            midpoint = crouchMidpoint;
            bobbingSpeed = crouchBobbingSpeed;
            bobbingAmount = 0.05f;

        }
        else
        {
            midpoint = 0.577f;
            bobbingSpeed = maxSpeed;
            bobbingAmount = 0.1f;

        }



        if (PlayerMovment.Grounded != false)
        {
            if (waveslice != 0)
            {

                float translateChange = waveslice * bobbingAmount;
                float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                cSharpConversion.y = midpoint + translateChange;

            }
            else
            {
                cSharpConversion.y = midpoint;
            }

            transform.localPosition = cSharpConversion;
        }
    }
}

