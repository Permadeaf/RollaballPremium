using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public AK.Wwise.RTPC DistanceToGroundRTPC;
    public PlayerRaycast DistanceToGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            var distanceToGround = hit.distance;
            
        }
        DistanceToGroundRTPC.SetGlobalValue(hit.distance);
        
    }

    
    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.LogWarning("Hit: " + other.gameObject.name);
    //     var soundMat = other.gameObject.GetComponent<SoundMaterial>();
    //     if (soundMat != null)
    //     {
    //         soundMat.Switch(gameObject);
    //     }
    // }
}
