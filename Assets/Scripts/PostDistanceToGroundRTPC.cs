using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDistanceToGroundRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC DistanceToGroundRTPC;
    public PlayerRaycast DistanceToGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceToGround.RaycastHit)
        {
            DistanceToGroundRTPC.SetGlobalValue(DistanceToGround.HitData.distance);
        }
    }
}
