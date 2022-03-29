using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindySoundEvent : MonoBehaviour

    
{
    public AK.Wwise.Event WindyAmbienceEvent;

    // Start is called before the first frame update
    void Start()
    {
        WindyAmbienceEvent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
