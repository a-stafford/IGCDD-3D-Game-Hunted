using UnityEngine;
using System.Collections;

public class WalkSound : MonoBehaviour
{

    public float Height, LowestHeight, HighestHeight;
    public GameObject Camera;
    public bool High = true, step, played = false;
    // Use this for initialization
    void Start()
    {
        Height = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        LowestHeight = transform.position.y;
        HighestHeight = transform.position.y;

        if (LowestHeight < Height && LowestHeight < 17.6 && PlayerMovment.Crouching == false && played == false)
        {
            //Debug.Log(LowestHeight);
            if (step == true)
            {
                SoundEffects.Instance.MakePlayerWalkSoundOne();
                Debug.Log("One");
                step = false;
                High = false;
                played = true;
            }
            if (step == false && High == true)
            {
                SoundEffects.Instance.MakePlayerWalkSoundTwo();
                Debug.Log("Two");
                step = true;
                played = true;
            }

        }

        if (HighestHeight > Height && HighestHeight > 19f && PlayerMovment.Crouching == false)
        {

            High = true;
            played = false;
        }
    }
}
