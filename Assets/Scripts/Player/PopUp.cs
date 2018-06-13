using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text WeaponText;


    void Start()
    {
        WeaponText.enabled = false;
    }

    void Update()
    {
        AutoFire();
        Invincible();
        
    }

    void AutoFire()
    {
        if (PowerUp.crazy == true)
        {
            WeaponText.text = "Auto Fire";
            WeaponText.enabled = true;
        }

        if (PowerUp.crazy == false && PowerUp.invincible == false)
        {
            WeaponText.enabled = false;
        }

    }

    void Invincible()
    {
        if (PowerUp.invincible == true)
        {
            WeaponText.text = "Invincible";
            WeaponText.enabled = true;
        }

        if (PowerUp.invincible == false && PowerUp.crazy == false)
        {
            WeaponText.enabled = false;
        }
    }
}
