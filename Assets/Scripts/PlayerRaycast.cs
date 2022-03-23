using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();

    public RaycastHit HitData { get { return hit; } }

    bool raycastHit = false;

    public bool RaycastHit { get { return raycastHit; } }


    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        raycastHit = Physics.Raycast(transform.position, -Vector3.up, out hit);
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
