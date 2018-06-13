using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int randNum;
    public float timer = 5f;
    private int maxHearts = 2;
    private int maxHealth;
    private int healthPerHeart = 5;
    public int startHearts = 2;
    public static int currentHealth;
    public Image[] healthImages;
    public Sprite[] healthSprites;
    public Transform[] playerSpawn;


    void Start()
    {
        currentHealth = startHearts * healthPerHeart;
        checkHealthAmount();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (PowerUp.invincible == false)
            {
                currentHealth--;
                UpdateHearts();
            }
            teleportPlayer();
        }
    }

    void checkHealthAmount()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;

            }
            else
            {
                healthImages[i].enabled = true;
            }
        }

        UpdateHearts();

    }
    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;
        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if (currentHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageindex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageindex];
                    empty = true;
                }
            }
        }

    }

    public void takeDamage(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startHearts * healthPerHeart);
        UpdateHearts();
    }

    public void addHeart()
    {
        startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHearts);
        checkHealthAmount();
    }


   void Update()
    {
        randNum = Random.Range(0, 9);

        if (PowerUp.invincible == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && PowerUp.invincible == true)
        {
            PowerUp.invincible = false;
            Debug.Log("invinc off");
            timer = 5f;
        }
    }
    public void teleportPlayer()
    {
        gameObject.transform.position = playerSpawn[randNum].transform.position;
        Debug.Log("Teleported " + randNum);
    }

}
