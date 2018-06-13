using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{
    public float timer = 1f;

    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }


}

