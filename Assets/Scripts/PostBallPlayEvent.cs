using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBallPlayEvent : MonoBehaviour
{
    public AK.Wwise.Event BallRollEvent;
    // Start is called before the first frame update
    void Start()
    {

        BallRollEvent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
