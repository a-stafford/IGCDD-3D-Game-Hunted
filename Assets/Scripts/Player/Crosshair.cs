using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    Rect crosshairRect, ShotRect;
    public float size = 0.05f;
    public float ShSize = 0.05f;
    public Texture crosshairTexture;
    public Texture ShotgunTexture;


    // Use this for initialization
    void Start () {
        float crosshairSize = Screen.width * size;
        float shotSize = Screen.width * ShSize;

        crosshairRect = new Rect(Screen.width / 2 - crosshairSize / 2, Screen.height / 2 - crosshairSize / 2, crosshairSize, crosshairSize);
        ShotRect = new Rect(Screen.width / 2 - shotSize / 2, Screen.height / 2 - shotSize / 2, shotSize, shotSize);
    }
	
	// Update is called once per frame
	void OnGUI()
    {
        if (Shoot.Pistol == true)
        {
            GUI.DrawTexture(crosshairRect, crosshairTexture);
        }

        if (Shoot.Shotgun == true)
        {
            GUI.DrawTexture(ShotRect, ShotgunTexture);
        }


    }
	
	
}
