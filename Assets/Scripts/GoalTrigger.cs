using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GoalTrigger : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event Event;

    public UnityEvent OnGoalReached;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.CanMove = false;
            player.Stop();
            OnGoalReached.Invoke();
            Event.Post(gameObject);
        }
    }
}
