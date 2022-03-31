using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC SkidFactor;
    public AK.Wwise.RTPC AngularSpeed;
    [SerializeField]
    Rigidbody playerBody;

    float threshhold;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.localScale != Vector3.one)
        {
            Debug.LogError("You might need to redo your SkidRTPC calculation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angularDist;
        angularDist.z = playerBody.angularVelocity.x * transform.localScale.x / 2;
        angularDist.x = playerBody.angularVelocity.z * transform.localScale.z / 2;
        angularDist.y = 0; //TODO: come back to this

        Vector3 playerSpeed = playerBody.velocity;
        playerSpeed.y = 0;


        SkidFactor.SetGlobalValue(Mathf.Abs(playerSpeed.magnitude - angularDist.magnitude));
        AngularSpeed.SetGlobalValue(angularDist.magnitude);

        Debug.LogWarning("Skid: " + Mathf.Abs(playerSpeed.magnitude - angularDist.magnitude).ToString("F2"));
        Debug.LogWarning("Spin: " + Mathf.Abs(angularDist.magnitude).ToString("F2"));

    }


}
