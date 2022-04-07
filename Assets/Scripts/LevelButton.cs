using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    TMP_Text textBox;

    string levelPath = "";


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        if (levelPath != null && levelPath != "")
        {
            SceneManager.LoadScene(levelPath, LoadSceneMode.Single);
        }
    }

    public void SetData(LevelDataSO data)
    {
        textBox.text = data.LevelName;
        levelPath = data.ScenePath;
    }
}
