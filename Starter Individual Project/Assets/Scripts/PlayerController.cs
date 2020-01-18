using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    Vector2 movement;

    public AudioClip gameOverSong;
    public AudioClip victorySong;
    public AudioClip collideSound;
    public AudioClip startSound;

    public AudioSource musicSource;

    public Text winText;
    public Text loseText;
    public Text livesText;
    public Text restartText;

    private int lives;

    internal static object other;

    public bool gameOver;
    public bool isDead;

    void Start()
    {
        musicSource.clip = startSound;
        musicSource.Play();
        gameOver = false;
        rb2d = GetComponent<Rigidbody2D>();
        lives = 3;
        winText.text = "";
        loseText.text = "";
        restartText.text = "";
        SetAllText();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void SetAllText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            Destroy(gameObject);
            loseText.text = "Game over...";
            restartText.text = "Click the restart button to try again!";
            isDead = true;
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.SetActive(false);
            winText.text = "You win!";
            restartText.text = "Click the restart button if you want to try again!";
            Destroy(gameObject);
            musicSource.clip = victorySong;
            musicSource.Play();
        }
        if (other.gameObject.CompareTag("Spike"))
        {
            musicSource.clip = collideSound;
            musicSource.Play();
            lives = lives - 1;
            SetAllText();
        }
    }

    public void GameOver()
    {
        musicSource.clip = gameOverSong;
        musicSource.Play();
        gameOver = true;
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }
}
