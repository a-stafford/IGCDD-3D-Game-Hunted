using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class PauseScript : MonoBehaviour {

    public Transform canvas;
    public Transform Player, Camera, Gun;

    void Start () {
        canvas.gameObject.SetActive(false);
    }
    //this script controls the in-game pause screen
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();

        }
    }
    //Resume method resumes the game after the player exits the pause menu
    public void Resume()
    {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                Player.GetComponent<PlayerMovment>().enabled = false;
                Gun.GetComponent<Shoot>().enabled = false;
                Gun.GetComponent<Crosshair>().enabled = false;
                Camera.GetComponent<MouseLook>().enabled = false;
                
        }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                Player.GetComponent<PlayerMovment>().enabled = true;
                Gun.GetComponent<Shoot>().enabled = true;
                Gun.GetComponent<Crosshair>().enabled = true;
                Camera.GetComponent<MouseLook>().enabled = true;
        }
        }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        
    }
}

