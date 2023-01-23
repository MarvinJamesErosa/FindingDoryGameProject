using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeSceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject GameModeScreen;
    [SerializeField] private Slider ProgressBar;

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
}
