using UnityEngine;
using System.Collections;

public class CrouchSound : MonoBehaviour
{

    public float Height, LowestHeight, HighestHeight, low = 0f, h = 0f;
    public GameObject Camera;
    public bool H = true, steps, play = false;
    int i = 0;

    // Use this for initialization
    void Start()
    {
        play = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovment.Crouching == true && i == 0)
        {
            i = 1;
            play = false;
            Height = transform.position.y;
        }

        LowestHeight = transform.position.y;
        HighestHeight = transform.position.y;

        if (LowestHeight < Height && LowestHeight < 13.7 && PlayerMovment.Crouching == true && play == false)
        {

            if (steps == true)
            {
                SoundEffects.Instance.MakePlayerWalkSoundOne();
                steps = false;
                H = false;
                play = true;
            }
            if (steps == false && H == true)
            {
                SoundEffects.Instance.MakePlayerWalkSoundTwo();
                steps = true;
                play = true;
            }

        }

        if (HighestHeight > Height && HighestHeight > 14 && PlayerMovment.Crouching == true)
        {
            Debug.Log(HighestHeight);
            H = true;
            play = false;
        }
    }
}