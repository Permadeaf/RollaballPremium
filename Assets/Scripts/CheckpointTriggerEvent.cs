using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTriggerEvent : MonoBehaviour
{
    [SerializeField]
    PlayerReset playerReset;

    [SerializeField]
    Vector3 offset;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            playerReset.checkpointPosition = transform.position + offset;
        }
    }
}
