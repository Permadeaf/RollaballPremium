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

      private void OnCollisionEnter(Collision other)
    {
        Debug.LogWarning("Hit: " + other.gameObject.name);
        var soundMat = other.gameObject.GetComponent<SoundMaterial>();
        if (soundMat != null)
        {
            soundMat.Switch(gameObject);
            //BallRollEvent.Post(gameObject);
        }
    }
}
