using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    [SerializeField]
    List<LevelDataSO> levels;

    [SerializeField]
    LevelButton buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateButtons();
    }

    void CreateButtons()
    {
        foreach (var level in levels)
        {
            var prefab = Instantiate(buttonPrefab, transform) as LevelButton;
            prefab.SetData(level);
        }
    }
}
