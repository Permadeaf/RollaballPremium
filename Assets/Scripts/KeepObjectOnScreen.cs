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
    void LateUpdate()
    {
        CalculateSpeed();
    }

    void CalculateSpeed()
    {
        var viewPoint = cameraLooking.WorldToViewportPoint(objectToTrack.transform.position, Camera.MonoOrStereoscopicEye.Mono);

        var xDist = viewPoint.x < .5 ? xBorder.x - viewPoint.x : viewPoint.x - xBorder.y;
        var yDist = viewPoint.y < .5 ? yBorder.x - viewPoint.y : viewPoint.y - xBorder.y;

        var xSpeed = speedCurve.Evaluate(xDist);
        xSpeed *= viewPoint.x < .5 ? 1 : -1;


        var ySpeed = speedCurve.Evaluate(yDist);
        ySpeed *= viewPoint.y < .5 ? 1 : -1;

        Vector3 speedVector = new Vector3(xSpeed, 0, ySpeed).normalized;

        transform.position += -maxSpeed * speedVector * Time.deltaTime;
    }
}
