using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDistanceToGroundRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC DistanceToGroundRTPC;
    public PlayerRaycast DistanceToGround;

    const float MISS_VALUE = 10;

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
        else
        {
            DistanceToGroundRTPC.SetGlobalValue(MISS_VALUE);
        }
    }
}
