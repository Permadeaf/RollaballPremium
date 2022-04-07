using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToDangerRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC DistanceToDangerPostRTPC;
    public GameObject Player;
    public GameObject DangerObject;

    public float dist;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.transform.position, DangerObject.transform.position);
        DistanceToDangerPostRTPC.SetGlobalValue(dist);
    }
}
