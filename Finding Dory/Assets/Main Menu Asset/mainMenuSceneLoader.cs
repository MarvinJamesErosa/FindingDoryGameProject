using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuSceneLoader : MonoBehaviour
{
    public void selectionScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
