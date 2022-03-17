using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostSpeedRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC SpeedRTPC;
    public Rigidbody myRigidbody;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpeedRTPC.SetGlobalValue(myRigidbody.velocity.magnitude);
    }
}
