using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Button mainMenuButton;
    public Button retryButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        
        retryButton.onClick.AddListener(Retry);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Pinball");
    }
}
