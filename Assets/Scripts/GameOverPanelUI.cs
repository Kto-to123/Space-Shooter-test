using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelUI : MonoBehaviour
{
    public GameObject UI;

    private void Awake()
    {
        UI.SetActive(false);
        PlayerHealth.GameOver += Show;
    }

    private void OnDisable()
    {
        PlayerHealth.GameOver -= Show;
    }

    public void RestartThisScean()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Show()
    {
        UI.SetActive(true);
    }
}
