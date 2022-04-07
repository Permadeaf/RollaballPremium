using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Rollaball/Level Data")]
public class LevelDataSO : ScriptableObject
{
    [Tooltip("Name of level for button")]
    [SerializeField]
    string levelName;

    /// <summary>
    /// Name of level for button
    /// </summary>
    /// <value></value>
    public string LevelName
    {
        get
        {
            return levelName;
        }
    }

    [TooltipAttribute("Path to the scene in the unity project")]
    [SerializeField]
    string scenePath;

    /// <summary>
    /// Path to the scene in the unity project
    /// </summary>
    /// <value></value>    
    public string ScenePath
    {
        get
        {
            return scenePath;
        }
    }
}
