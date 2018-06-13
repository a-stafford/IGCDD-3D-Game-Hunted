using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    public float randNum, dropRate = 0.25f;
    public GameObject Power;
    public GameObject powerSpawn;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
            itemDrop();
            Destroy(collision.gameObject);
        }
    }

    void itemDrop()
    {
        randNum = Random.Range(0f, 1f);
        if (randNum <= dropRate)
        {
            Debug.Log("Dropped");
            Instantiate(Power, powerSpawn.transform.position, powerSpawn.transform.rotation);

        }
    }
}
