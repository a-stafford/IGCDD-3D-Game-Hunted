using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    //walk and run speed of player
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float crouchSpeed = 1.5f;
    public static bool Running, Grounded, Crouching;
    public static float i;
    int x = 0;
    private float translation, strafe;

    public GameObject c;
    private Rigidbody rb;



    void Start()
    {
        //locks cursor to game and hides cursor
        Cursor.lockState = CursorLockMode.Locked;
        Grounded = true;
        Crouching = false;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            Running = true;
            Debug.Log("Running");
        }

        if (Running == false)
        {
            translation = Input.GetAxis("Vertical") * walkSpeed;
            strafe = Input.GetAxis("Horizontal") * walkSpeed;
            translation *= Time.deltaTime;
            strafe *= Time.deltaTime;

        }

        if (Running == true && Crouching == false)
        {
            translation = Input.GetAxis("Vertical") * runSpeed;
            strafe = Input.GetAxis("Horizontal") * runSpeed;
            translation *= Time.deltaTime;
            strafe *= Time.deltaTime;
        }
        if (Input.GetKeyUp("left shift"))
        {
            Running = false;
            Debug.Log("Stopped Running");
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded)
            {
                Grounded = false;
                SoundEffects.Instance.MakeJumpSound();
                rb.velocity = new Vector3(0f, 15f, 0f);

            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!Crouching)
            {
                Debug.Log("Crouching");
                Crouching = true;
            }
            else
            {
                
                Crouching = false;
            }
        }

        if (Crouching == true)
        {
            translation = Input.GetAxis("Vertical") * crouchSpeed;
            strafe = Input.GetAxis("Horizontal") * crouchSpeed;
            translation *= Time.deltaTime;
            strafe *= Time.deltaTime;
        }


        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            //unlocks cursor and shows cursor
            Cursor.lockState = CursorLockMode.None;
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && x ==1)
        {
            SoundEffects.Instance.MakeLandingSound();
            Grounded = true;
        }
        x = 1;
    }
}
