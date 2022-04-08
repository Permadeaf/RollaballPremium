using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToDangerRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC DistanceToDangerPostRTPC;
    public GameObject Player;
    public GameObject DangerObject;

    [SerializeField]
    bool useUpdatedMethod = false;

    [SerializeField]
    EnemyBounceSetter bounceSetter;

    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        if (bounceSetter == null && useUpdatedMethod)
        {
            Debug.LogWarning("NOTE: You need to attach a EnemyBounceSetter to this object: (" + gameObject.name + ")");
        }
    }

    // Update is called once per frame
    void Update()
    {
        dist = useUpdatedMethod ? GetNearest() : Vector3.Distance(Player.transform.position, DangerObject.transform.position);
        DistanceToDangerPostRTPC.SetGlobalValue(dist);
    }

    float GetNearest()
    {
        if (bounceSetter == null)
        {
            return 50;
        }
        var enemies = bounceSetter.Enemies;
        float minDist = float.MaxValue;
        foreach (var enemy in enemies)
        {
            var distance = Vector3.Distance(Player.transform.position, enemy.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
            }
        }
        return minDist;
    }
}
