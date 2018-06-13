using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour
{
    int x = 0, y = 0, z = 0;
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Room1" && x < 1)
        {
            x++;
            EnemySpawn.Room1 = true;
            EnemySpawn.Room2 = false;
            EnemySpawn.Room3 = false;
            EnemySpawn.Die = true;
            y = 0;
            z = 0;
            Debug.Log("ENTERD ROOM 1");
        }

        if (collision.collider.tag == "Room2" && y < 1)
        {
            y++;
            EnemySpawn.Room1 = false;
            EnemySpawn.Room2 = true;
            EnemySpawn.Room3 = false;
            EnemySpawn.Die = true;
            x = 0;
            z = 0;
            Debug.Log("ENTERD ROOM 2");
        }

        if (collision.collider.tag == "Room3" && z < 1)
        {
            z++;
            EnemySpawn.Room1 = false;
            EnemySpawn.Room2 = false;
            EnemySpawn.Room3 = true;
            EnemySpawn.Die = true;
            x = 0;
            y = 0;
            Debug.Log("ENTERD ROOM 3");
        }
    }
}
