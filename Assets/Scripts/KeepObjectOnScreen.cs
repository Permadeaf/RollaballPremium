using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObjectOnScreen : MonoBehaviour
{
    [SerializeField]
    Camera cameraLooking;

    [SerializeField]
    GameObject objectToTrack;

    [Tooltip("0 <= X <= 1, X <= Y <=1 ")]
    [SerializeField]
    Vector2 xBorder;

    [Tooltip("0 <= X <=1, X <= Y <=1 ")]
    [SerializeField]
    Vector2 yBorder;

    [SerializeField]
    AnimationCurve speedCurve;

    [SerializeField]
    float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateSpeed();
    }

    void CalculateSpeed()
    {
        var viewPoint = cameraLooking.WorldToViewportPoint(objectToTrack.transform.position, Camera.MonoOrStereoscopicEye.Mono);
        //Debug.LogWarning("ViewPort: " + viewPoint);

        var xDist = viewPoint.x < .5 ? xBorder.x - viewPoint.x : viewPoint.x - xBorder.y;
        var yDist = viewPoint.y < .5 ? yBorder.x - viewPoint.y : viewPoint.y - xBorder.y;

        var xSpeed = speedCurve.Evaluate(xDist);
        xSpeed *= viewPoint.x < .5 ? 1 : -1;


        var ySpeed = speedCurve.Evaluate(yDist);
        ySpeed *= viewPoint.y < .5 ? 1 : -1;
        //ySpeed *= viewPoint.z < 0 ? 1 : -1;

        Vector3 speedVector = new Vector3(xSpeed, 0, ySpeed).normalized;

        Vector3 offset = -maxSpeed * speedVector * Time.fixedDeltaTime;
        transform.position = Vector3.Lerp(transform.position, transform.position + offset, .25f);
    }
}
