using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReturnToTitleScript : MonoBehaviour
{
    [SerializeField]
    PlayerInput input;

    [SerializeField]
    string titleScenePath;

    // Start is called before the first frame update
    void Start()
    {
        input.actions["Title"].started += OnQuit;
    }

    void OnQuit(InputAction.CallbackContext callbakContext)
    {
        if (callbakContext.started)
        {
            Debug.LogWarning("Title Screen");
            SceneManager.LoadScene(titleScenePath, LoadSceneMode.Single);
        }
    }

    private void OnDestroy()
    {
        input.actions["Title"].started -= OnQuit;
    }
}
