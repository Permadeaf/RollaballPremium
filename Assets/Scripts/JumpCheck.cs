using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    [SerializeField]
    float distance;

    bool currentlyInAir = false;

    public bool IsInAir()
    {
        return !Physics.Raycast(transform.position, Vector3.down, distance);
    }
}
