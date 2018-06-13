using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

    public Behaviour[] EnableOnInvisible;
    public Behaviour[] DisabledOnInvisible;
    public GameObject enemy;
    void OnBecameInvisible()
    {
        enemy.GetComponent<EnemyMove>().enabled = true;
        enemy.GetComponent<Animator>().enabled = true;
    }

    void OnBecameVisible()
    {
        enemy.GetComponent<EnemyMove>().enabled = false;
        enemy.GetComponent<Animator>().enabled = false;
    }
}
