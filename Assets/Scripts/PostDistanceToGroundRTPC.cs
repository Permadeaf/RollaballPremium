using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDistanceToGroundRTPC : MonoBehaviour
{
    [SerializeField]
    SphereCollider playerCollider;

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
            DistanceToGroundRTPC.SetGlobalValue(Mathf.Max(0, DistanceToGround.HitData.distance - playerCollider.radius));
        }
        else
        {
            DistanceToGroundRTPC.SetGlobalValue(MISS_VALUE);
        }
    }
}
