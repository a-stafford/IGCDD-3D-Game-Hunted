using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public float minutes = 0f, seconds = 0f, survivalTime;
    public Image backgroundImg;
    public Text timeText, DeathTimeText, LTText;
    public GameObject deathScreen;
    public bool isDead = false;
    private float transition = 0.0f, startTime, fMinutes = 0f, fSeconds = 0f;
    public string FinalTime, playTime, minute, second;
    public Transform Player, Camera, Gun;

    void Start()
    {
        //PlayerPrefs.SetString("Final", "00:00");
        minutes = 0f;
        seconds = 0f;
        timeText = GetComponent<Text>();

        FinalTime = PlayerPrefs.GetString("Final");
        LTText.text = "Longest Time Survived: " + FinalTime;

        string[] time = FinalTime.Split(':');
        fMinutes = float.Parse(time[0]);
        fSeconds = float.Parse(time[1]);

        deathScreen.SetActive(false);
        startTime = Time.timeSinceLevelLoad;

    }

    void Update()
    {
        float t = Time.timeSinceLevelLoad + startTime;
        minutes = ((int)t / 60);
        seconds = ((int)t % 60);
        minute = ((int)t / 60).ToString("00");
        second = (t % 60).ToString("00");

        playTime = minute + ":" + second;
        if (minutes > 1) {
            EnemySpawn.maxEnemies = minutes;
                }
        timeText.text = "Time: " + playTime;

        DeadScreen();
    }

    void DeadScreen()
    {
        if (deathScreen.gameObject.activeInHierarchy == false)
        {
            FinalTime = playTime;
        }
        
        if (HeartSystem.currentHealth <= 0)
        {
            Player.GetComponent<PlayerMovment>().enabled = false;
            Gun.GetComponent<Shoot>().enabled = false;
            Gun.GetComponent<Crosshair>().enabled = false;
            Camera.GetComponent<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            transition += Time.deltaTime;
            backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
            deathScreen.SetActive(true);

            DeathTimeText.text = "Final Time: " + FinalTime;

            if (minutes >= fMinutes && seconds > fSeconds)
            {
                PlayerPrefs.SetString("Final", FinalTime);
            }
            else
            {
                if (minutes >= fMinutes && seconds < fSeconds && minutes >= 01)
                {
                    PlayerPrefs.SetString("Final", FinalTime);
                }
            }
        }
    }
}

