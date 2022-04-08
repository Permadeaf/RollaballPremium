using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleSoundEvent : MonoBehaviour

    
{
    public AK.Wwise.Event SparkleEvent;

    // Start is called before the first frame update
    void Start()
    {
        SparkleEvent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
