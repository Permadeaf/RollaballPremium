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
    Vector3 distanceTraveled;

    Vector3 previousDistanceTraveled;

    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentTime = (currentTime + Time.fixedDeltaTime) % period;
        UpdatePosition();
    }

    void UpdatePosition()
    {
        transform.localPosition = startingPosition + distanceTraveled * Mathf.Sin(2 * Mathf.PI * currentTime / period);
    }

    private void OnValidate()
    {
        currentTime %= period;
        UpdatePosition();
    }
}
