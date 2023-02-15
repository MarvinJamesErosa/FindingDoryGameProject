using UnityEngine;
using UnityEngine.UI;

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
    public GameObject sharkguess;
    public GameObject pauseButton;

    public int score { get; private set; }

    private void Awake()
    {
        gameOver.SetActive(false);
        continue1.SetActive(false);
        answerButton.SetActive(false);
        skipButton.SetActive(false);
        sharkguess.SetActive(false);
        pauseButton.SetActive(false);

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
        sharkguess.SetActive(false);
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
        sharkguess.SetActive(true);
        Pause();
    }
    public void GameOver()
    {
        playButton.SetActive(false);
        continue1.SetActive(false);
        gameOver.SetActive(true);
        answerButton.SetActive(false);
        skipButton.SetActive(false);
        sharkguess.SetActive(false);
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
        player.enabled = false;


    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
