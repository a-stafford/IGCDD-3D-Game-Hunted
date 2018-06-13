using UnityEngine;
using System.Collections;

public class FacingPlayer : MonoBehaviour
{
    public Transform myTarget;

    void Update()
    {
        transform.LookAt(new Vector3(myTarget.position.x, transform.position.y, myTarget.position.z));
    }
}
