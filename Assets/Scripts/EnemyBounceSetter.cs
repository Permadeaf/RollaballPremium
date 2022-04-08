using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyBounceSetter : MonoBehaviour
{
    [SerializeField]
    AkEvent eventToTrack;

    [SerializeField]
    AK.Wwise.CallbackFlags flags;

    [SerializeField]
    string functionName;

    public List<Enemy> Enemies { get; protected set; }

    private void Awake()
    {
        eventToTrack.useCallbacks = true;
        Enemies = GameObject.FindObjectsOfType<Enemy>().ToList();
        foreach (var enemy in Enemies)
        {
            eventToTrack.Callbacks.Add(new AkEvent.CallbackData { GameObject = enemy.gameObject, FunctionName = functionName, Flags = flags });
        }
    }
}
