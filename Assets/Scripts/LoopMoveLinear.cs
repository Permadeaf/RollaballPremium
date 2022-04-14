using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMoveLinear : MonoBehaviour
{
    [SerializeField]
    float currentTime;

    [SerializeField]
    float period;

    [SerializeField]
    GameObject zeroPoint;

    [SerializeField]
    Rigidbody body;

    [SerializeField]
    bool useBody = false;

    [SerializeField]
    Vector3 distanceTraveled;

    Vector3 previousDistanceTraveled;

    Vector3 startingPosition;

    Vector3 startingPositionBody;

    // Start is called before the first frame update
    void Start()
    {
        if (useBody && body != null)
        {
            startingPositionBody = zeroPoint.transform.position;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentTime = (currentTime + Time.fixedDeltaTime) % period;
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if (useBody && body != null)
        {
            body.MovePosition(startingPositionBody + distanceTraveled * Mathf.Sin(2 * Mathf.PI * currentTime / period));
        }
        else
        {
            transform.localPosition = startingPosition + distanceTraveled * Mathf.Sin(2 * Mathf.PI * currentTime / period);
        }

    }

    private void OnValidate()
    {
        currentTime %= period;
        UpdatePosition();
    }
}
