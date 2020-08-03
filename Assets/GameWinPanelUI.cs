using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinPanelUI : MonoBehaviour
{
    public GameObject UI;

    private void Awake()
    {
        UI.SetActive(false);
        Progress.GameWin += Show;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Show()
    {
        UI.SetActive(true);
    }
}
