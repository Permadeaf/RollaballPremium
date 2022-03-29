using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyCameraController : MonoBehaviour
{
    [SerializeField]
    float maxSpeed;

    [SerializeField]
    AnimationCurve speedCurve;

    [SerializeField]
    float maxDistanceMultiplier;

    [SerializeField]
    float minDistanceMultiplier;

    [SerializeField]
    GameObject objectToTrack;

    Vector3 initialDistanceVector;

    float maxDistance;

    float minDistance;


    // Start is called before the first frame update
    void Start()
    {
        initialDistanceVector = objectToTrack.transform.position - transform.position;
        maxDistance = initialDistanceVector.sqrMagnitude * maxDistanceMultiplier;
        minDistance = initialDistanceVector.sqrMagnitude * minDistanceMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
    }

    void CalculateDistance()
    {
        var distance = objectToTrack.transform.position - transform.position;
        var normalVector = distance.normalized;

        var normalizedDistance = (distance.sqrMagnitude - minDistance) / (maxDistance - minDistance);

        var speed = maxSpeed * speedCurve.Evaluate(normalizedDistance);

        transform.position += normalVector * speed;
    }
}
