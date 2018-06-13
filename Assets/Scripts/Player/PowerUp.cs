using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUp : MonoBehaviour
{

    public static bool crazy = false, time = false, invincible = false;
    public int randNum;
    public Text WeaponText;


    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            randNum = Random.Range(1, 3);
            Debug.Log(randNum);
            if (randNum == 1 && invincible != true)
            {
                crazy = true;
                time = true;
                Debug.Log("CrazyFire");
            }

            if (randNum == 2 && crazy != true)
            {
                invincible = true;
                time = true;
                Debug.Log("invincible");
            }
            this.gameObject.SetActive(false);
        }
    }
}
