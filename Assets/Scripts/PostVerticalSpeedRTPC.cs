using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostVerticalSpeedRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC VerticalSpeedRTPC;
    public Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //VerticalSpeedRTPC.SetGlobalValue(myRigidbody.velocity.y);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.contactCount > 0)
        {
            VerticalSpeedRTPC.SetGlobalValue(Mathf.Abs(Vector3.Dot(other.contacts[0].normal, other.relativeVelocity)));
        }
    }
}
