using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathTriggerEvent : MonoBehaviour
{
    public UnityEvent OnDeathTriggerReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            OnDeathTriggerReached.Invoke();
        }
    }
}
