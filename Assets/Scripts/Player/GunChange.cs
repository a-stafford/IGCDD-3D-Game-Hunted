using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunChange : MonoBehaviour {
    public GameObject[] Guns;
    public static bool GunText1, GunText2;
    public Text WeaponText;

    // Use this for initialization
    void Start () {
      
        WeaponText.text = "Pistol";
    }
	
	// Update is called once per frame
	void Update () {
        
        if (GunText1 == true)
        {
            Gun1();
        }

        if (GunText2 == true)
        {
            Gun2();
        }
    }


    void Gun1()
    {
        Guns[0].SetActive(true);
        WeaponText.text = "Pistol";
        Guns[1].SetActive(false);
    }

    void Gun2()
    {
       Guns[1].SetActive(true);
        WeaponText.text = "Shotgun";
        Guns[0].SetActive(false);

    }

}
