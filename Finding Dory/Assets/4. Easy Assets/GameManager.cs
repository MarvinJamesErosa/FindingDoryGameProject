using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    public Text scoreText;
    public GameObject continue1;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject answerButton;
    public GameObject skipButton;
    public GameObject pauseButton;
    public GameObject pausescreen;
    public GameObject shark;
    public GameObject eel;
    public GameObject S;
    public GameObject H;
    public GameObject A;
    public GameObject R;
    public GameObject K;
    public GameObject E;
    public GameObject E2;
    public GameObject L;
    public bool isCorrect;



    public int score { get; private set; }

    private void Awake()
    {
        gameOver.SetActive(false);
        continue1.SetActive(false);
        answerButton.SetActive(false);
        skipButton.SetActive(false);
        pauseButton.SetActive(false);
        pausescreen.SetActive(false);

        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        pauseButton.SetActive(true);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Continue()
    {
        continue1.SetActive(true);
        answerButton.SetActive(true);
        skipButton.SetActive(true);
        Pause();
    }
    public void Answer()
    {   
        GameObject[] fishes = { shark, eel };
        int randomIndex = Random.Range(0, fishes.Length);
        GameObject randomFish = fishes[randomIndex];

        randomFish.SetActive(true);
        foreach (GameObject fish in fishes)
        {
            if(fish != randomFish)
            {
                fish.SetActive(false);
            }
        }
    }

    public void sharkcheck1()
    {
        if (S != null && S.GetComponent<InputField>() != null && 
            S.GetComponent<InputField>().text.ToLower() == "s")
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
    }    

    public void SubmitShark()
    {
        if (isCorrect == false)
        {
            shark.SetActive(false);
            eel.SetActive(false);
            Resume();
        }
        else
        {
            GameOver();
        }
        Resume();
    }

    public void GameOver()
    {
        playButton.SetActive(false);
        continue1.SetActive(false);
        gameOver.SetActive(true);
        answerButton.SetActive(false);
        skipButton.SetActive(false);
        shark.SetActive(false);
        eel.SetActive(false);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Pause1()
    {
        Time.timeScale = 0f;
        pausescreen.SetActive(true);
    }
    public void Resume()
    {
        pausescreen.SetActive(false);
        player.enabled = true;
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
