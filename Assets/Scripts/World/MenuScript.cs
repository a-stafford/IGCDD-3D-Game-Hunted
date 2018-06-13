using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public Text highScoreText;

	//this script controls the menu screen 
	void Start () {
        string FinalTime = PlayerPrefs.GetString("Final");
        highScoreText.text = "Longest Time Survived:  " + FinalTime;
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;

	}
	
    //when the exit button is pressed it enables the right canvas and buttons
	public void ExitPress()
    {
        Debug.Log("working");
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;

    }

    //when the no button is pressed it enables the right canvas and buttons
    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void Guide()
    {
        SceneManager.LoadScene("Guide");

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetString("Final", "00:00");
        highScoreText.text = "Longest Time Survived: 00:00";

    }

}
