using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlsController : MonoBehaviour
{
    [SerializeField] LevelsInfoSave saves;
    [SerializeField] List<Button> LevelButtons;
    [SerializeField] Sprite complitedSprite;

    private void Start()
    {
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            switch (saves.data.levelstates[i])
            {
                case SerializableData.LevelStates.Closed:
                    LevelButtons[i].interactable = false;
                    break;
                case SerializableData.LevelStates.Open:
                    LevelButtons[i].interactable = true;
                    break;
                case SerializableData.LevelStates.Complited:
                    LevelButtons[i].interactable = true;
                    ColorBlock colors = LevelButtons[i].colors;
                    colors.normalColor = Color.yellow;
                    LevelButtons[i].gameObject.GetComponent<Image>().sprite = complitedSprite;
                    break;
            }
        }
    }

    public void StartLvl(string name)
    {
        SceneManager.LoadScene(name);
    }
}
