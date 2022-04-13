using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    [SerializeField]
    float velocityMultiplier;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();

        if (player != null && other.body is Rigidbody)
        {
            Rigidbody body = (Rigidbody)other.body;
            body.velocity *= velocityMultiplier;
        }
    }
}
