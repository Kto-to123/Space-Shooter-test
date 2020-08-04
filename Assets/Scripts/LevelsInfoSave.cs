using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelsInfoSave : ScriptableObject
{
    [SerializeField]
    public SerializableData data;

    public void SaveData()
    {
        PlayerPrefs.SetString("SaveKey", JsonUtility.ToJson(data));
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("SaveKey"))
        {
            string json = PlayerPrefs.GetString("SaveKey");
            data = JsonUtility.FromJson<SerializableData>(json);
        }
    }
}

[Serializable]
public struct SerializableData
{
    public enum LevelStates
    {
        Closed,
        Open,
        Complited
    }

    [SerializeField]
    public LevelStates[] levelstates;
}
