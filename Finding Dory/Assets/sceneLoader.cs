using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
 // This is the various objects
// Loading screen, game mode screen, progress bar, and option screen
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject GameModeScreen;
    [SerializeField] private Slider ProgressBar;
    [SerializeField] private GameObject OptionScreen;

    // Tracks the previous scene's build index
    static int prevIndex;

    // Loads the selection scene
    public void SelectionScene()
    {
        SceneManager.LoadScene(2);
    }

    // Loads the menu scene
    public void MenuScene()
    {
        SceneManager.LoadScene(1);
    }

    // Loads the option scene and sets the option screen's sorting order to 2 in order to put it infront
    public void OptionScene()
    {
        prevIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(prevIndex);

        Canvas renderer = OptionScreen.GetComponent<Canvas>();
        renderer.sortingOrder = 2;
    }

    // Loads the how to play scene
    public void HowToPlayScene()
    {
        SceneManager.LoadScene(6);
    }

    // Loads the about us scene
    public void AboutUsScene()
    {
        SceneManager.LoadScene(7);
    }

    // Loads the specified game mode and shows the loading screen
    // Uses a coroutine to display the loading progress
    public void GameMode(int BuildIndex)
    {
        GameModeScreen.SetActive(false);
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadSequence(BuildIndex));
    }

    IEnumerator LoadSequence(int BuildIndex)
    {
        AsyncOperation Progress = SceneManager.LoadSceneAsync(BuildIndex);

        while (!Progress.isDone)
        {
            float ProgressValue = Mathf.Clamp01(Progress.progress / 0.9f);
            yield return null;
        }

        yield return new WaitForSeconds(1f); // Add a delay of 1 second
    }

    // Returns to the previous scene and hides the loading screen
    public void ReturnFunc()
    {
        SceneManager.LoadScene(prevIndex);
    }

    // Quits the game
    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }

    // Returns from the option scene and sets the option screen's sorting order back to 0
    public void OptionReturn()
    {
        Canvas renderer = OptionScreen.GetComponent<Canvas>();
        renderer.sortingOrder = 0;
    }
}
