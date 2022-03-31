using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    [SerializeField]
    Rigidbody player;

    public Vector3 checkpointPosition;

    private void Start()
    {
        checkpointPosition = player.transform.position;
    }

    public void ResetPlayer()
    {
        player.angularVelocity = Vector3.zero;
        player.velocity = Vector3.zero;
        player.transform.position = checkpointPosition;
    }
}
