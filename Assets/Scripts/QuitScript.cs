using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitScript : MonoBehaviour
{
    [SerializeField]
    PlayerInput input;

    // Start is called before the first frame update
    void Start()
    {
        input.actions["Quit"].started += OnQuit;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnQuit(InputAction.CallbackContext callbakContext)
    {
        if (callbakContext.started)
        {
            Debug.LogWarning("Quitting");
            Application.Quit();
        }
    }

    private void OnDestroy()
    {
        if (input != null)
        {
            input.actions["Quit"].started -= OnQuit;
        }
    }
}
