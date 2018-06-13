using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public static bool Room1  = true, Room2, Room3, Die = false;
    public Transform testSpawn;
    public float timeDelay = 2f, respawnCooldown;
    public int randNum;
    public static float maxEnemies = 1, numberOfEnemies;
    public Transform[] roomOneSpawns, roomTwoSpawns, roomThreeSpawns;
    public GameObject[] enemies;


    // Update is called once per frame
    void Update()
    {
        if(Die == true)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemies");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
                Debug.Log("Destroyed " + i);
            }
            Die = false;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        numberOfEnemies = enemies.Length;
        randNum = Random.Range(0, 7);
        if (numberOfEnemies < maxEnemies)
        {
            
            respawnCooldown -= Time.deltaTime;
            if (respawnCooldown <= 0)
            {
                if (Room1 == true) { 
                Instantiate(Enemy, roomOneSpawns[randNum].transform.position, roomOneSpawns[randNum].transform.rotation);
                Debug.Log("SPAWN ONE");
            }

                if (Room2 == true)
                {
                    Instantiate(Enemy, roomTwoSpawns[randNum].transform.position, roomTwoSpawns[randNum].transform.rotation);
                    Debug.Log("SPAWN TWO");
                }

                if (Room3 == true)
                {
                    Instantiate(Enemy, roomThreeSpawns[randNum].transform.position, roomThreeSpawns[randNum].transform.rotation);
                    Debug.Log("SPAWN THREE");
                }

                respawnCooldown = timeDelay;
            }
        }
    }
}
