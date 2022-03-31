using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAmbience : MonoBehaviour
{
    public AK.Wwise.Event Ambience;

    // Start is called before the first frame update
    void Start()
    {
        Ambience.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
