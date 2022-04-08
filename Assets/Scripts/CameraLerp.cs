using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    AnimationCurve trackCurve;

    [SerializeField]
    float distanceMultiplier;

    float distance;

    Vector3 normalizedVector;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 distanceVector = (transform.position - player.transform.position);
        normalizedVector = distanceVector.normalized;
        distance = distanceVector.magnitude;
        //Debug.LogWarning("Original Position: " + transform.position + " Distance: " + distance + " From Player: " + (player.transform.position + normalizedVector * distance));
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }


    void MoveCamera()
    {
        var targetPoint = player.transform.position + normalizedVector * distance;
        var distanceToTarget = (targetPoint - transform.position).magnitude;
        var math = Mathf.Abs((distanceToTarget - distance) / ((distanceMultiplier * distance) - distance));
        var time = trackCurve.Evaluate(math);
        //Debug.LogWarning("Current Pos: " + transform.position + " Player: " + player.transform.position + " Target: " + targetPoint + " Distance: " + distanceToTarget);
        //Debug.LogWarning("Math: " + math);
        if (!player.gameObject.GetComponent<Renderer>().isVisible)
        {
            Debug.LogWarning("Time: " + time + " Math: " + math);
        }
        transform.position = Vector3.Lerp(transform.position, targetPoint, time);
    }
}
