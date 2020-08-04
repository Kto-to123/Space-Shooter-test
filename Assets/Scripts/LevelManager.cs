using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelsInfoSave save;
    public int levelIndex;

    private void Start()
    {
        Progress.GameWin += Win;
    }

    void Win()
    {
        save.data.levelstates[levelIndex] = SerializableData.LevelStates.Complited;
        if (levelIndex < save.data.levelstates.Length -1)
        {
            save.data.levelstates[levelIndex + 1] = SerializableData.LevelStates.Open;
        }
        save.SaveData();
    }
}
