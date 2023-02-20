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
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject GameModeScreen;
    [SerializeField] private Slider ProgressBar;
    [SerializeField] private GameObject OptionScreen;

    static int prevIndex;
    public void SelectionScene()
    {
        SceneManager.LoadScene(2);
    }
    public void MenuScene()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionScene()
    {
        prevIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(prevIndex);
        
        Canvas renderer = OptionScreen.GetComponent<Canvas>();
        renderer.sortingOrder = 2;
    }
    public void HowToPlayScene()
    {
        SceneManager.LoadScene(6);
        
    }
    public void AboutUsScene()
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
        Canvas renderer = OptionScreen.GetComponent<Canvas>();
        renderer.sortingOrder = 0;
    }
    
    public void ReturnFunc()
    {
        SceneManager.LoadScene(prevIndex);
    }
    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
