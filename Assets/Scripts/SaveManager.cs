using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] LevelsInfoSave save;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        save.LoadData();
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
            save.SaveData();
    }

    private void OnApplicationQuit()
    {
        save.SaveData();
    }
}
