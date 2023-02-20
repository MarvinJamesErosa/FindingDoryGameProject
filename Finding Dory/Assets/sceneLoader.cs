using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject GameModeScreen;
    [SerializeField] private Slider ProgressBar;

    static int prevIndex;
    public void selectionScene()
    {
        SceneManager.LoadScene(2);
    }
    public void menuScene()
    {
        SceneManager.LoadScene(1);
    }
    public void optionScene()
    {
        prevIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(prevIndex);
        SceneManager.LoadScene(8);
    }
    public void howToPlayScene()
    {
        SceneManager.LoadScene(6);
        
    }
    public void aboutUsScene()
    {
        SceneManager.LoadScene(7);
    }
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
    }
    public void OptionReturn()
    {
        SceneManager.LoadScene(prevIndex);
    }

    public void quitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
