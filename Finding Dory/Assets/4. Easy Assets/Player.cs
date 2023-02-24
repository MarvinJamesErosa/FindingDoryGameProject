using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity;
    public float strength = 5f;
    private bool isPaused;

    [SerializeField] private AudioSource clickSoundEffect;
    [SerializeField] private AudioSource scoreSoundEffect;
    [SerializeField] private AudioSource gameOverSoundEffect;

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    public void Pause()
    {
        Time.timeScale += 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale += 1f;
        isPaused = false;
    }

    private void Update()
    {
        if (isPaused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                direction = Vector3.up * strength * 3;
                clickSoundEffect.Play();
            }
        }

        direction.y += gravity * Time.deltaTime * 3/2;
        transform.position += direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {  
            gameOverSoundEffect.Play();
            FindObjectOfType<GameManager>().Continue();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            scoreSoundEffect.Play();
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
