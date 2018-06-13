using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour
{

    public static SoundEffects Instance;
    public AudioClip PlayerWalkSoundOne, PlayerWalkSoundTwo;
    public AudioClip JumpSound, LandingSound;
    public AudioClip ShotSound;
    // public AudioClip pickupSound;
    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of soundEffects!");
        }
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    public void MakePlayerWalkSoundOne()
    {
        MakeSound(PlayerWalkSoundOne);
    }

    public void MakePlayerWalkSoundTwo()
    {
        MakeSound(PlayerWalkSoundTwo);
    }

    public void MakeJumpSound()
    {
        MakeSound(JumpSound);
    }

    public void MakeLandingSound()
    {
        MakeSound(LandingSound);
    }

    

    public void MakeShotSound()
    {
        MakeSound(ShotSound);
    }
    // Play a given sound
    private void MakeSound(AudioClip originalClip)
    {
        // As it is not 3D audio clip, position doesn't matter.
        GetComponent<AudioSource>().volume = 1;
        AudioSource.PlayClipAtPoint(originalClip,
        transform.position);
    }
}

