using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;
    //private Animator Enemy;


    void Start()
    {
        //Enemy = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        faceEnemy();
        enemyMovement();
       /* if (Input.GetKey("g"))
        {
            Enemy.SetTrigger("Attack");
            
        }*/
    }

    void faceEnemy()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    void enemyMovement()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, 0, speed * Time.deltaTime);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}