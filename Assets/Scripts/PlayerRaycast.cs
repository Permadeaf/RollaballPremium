using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField]
    List<Vector3> rayCastDirections;

    [SerializeField]
    float distance;

    RaycastHit hit = new RaycastHit();

    List<RaycastHit> hitRaycasts = new List<RaycastHit>();

    /// <summary>
    /// Returns ray with closest hit data to ground
    /// </summary>
    /// <value></value>
    public RaycastHit HitData
    {
        get
        {
            RaycastHit closest = new RaycastHit();
            float minDistance = float.MaxValue;

            foreach (var hit in hitRaycasts)
            {
                if (hit.distance < minDistance)
                {
                    minDistance = hit.distance;
                    closest = hit;
                }
            }
            return closest;
        }
    }

    bool raycastHit = false;

    public bool RaycastHit
    {
        get
        {
            return hitRaycasts.Count != 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        DoRaycasts();
    }


    void DoRaycasts()
    {
        hitRaycasts.Clear();
        foreach (var ray in rayCastDirections)
        {
            RaycastHit tempHit;
            if (Physics.Raycast(transform.position, ray, out tempHit, distance))
            {
                hitRaycasts.Add(tempHit);
            }
        }
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
