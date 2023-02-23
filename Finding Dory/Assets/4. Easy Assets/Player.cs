using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {  
            clickSoundEffect.Play();
            direction = Vector3.up * strength * 3;
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
