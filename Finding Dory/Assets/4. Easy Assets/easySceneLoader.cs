using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class easySceneLoader : MonoBehaviour
{
    public void menuScene()
    {
        SceneManager.LoadScene(1);
    }
    public void optionScene()
    {
        SceneManager.LoadScene(6);
    }
}
