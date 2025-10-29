using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; } = 0;
    public int Health { get; private set; } = 100;

    public TMP_Text scoreText;
    public TMP_Text healthText;

    // Add a reference to the GameOverText component
    public GameOverDisplay gameOverDisplay;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                ReturnToMenu();
            }

            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                ReturnToMenu();
            }
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateUI();
    }

    public void ReduceHealth(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
        UpdateUI();

        if (Health == 0)
        {
            GameOver();
        }
    }

    public void SetHealth(int amount)
    {
        Health = amount;
        UpdateUI();

        if (Health == 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = $"{Score}";
        healthText.text = $"{Health}";
    }

    void GameOver()
    {
        Debug.Log("Game Over!");

        isGameOver = true;

        if (gameOverDisplay != null)
        {
            gameOverDisplay.ShowGameOver();
        }
        else
        {
            Debug.LogWarning("GameOverText reference is not set in GameManager.");
        }
        Time.timeScale = 0f;

    }

    void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
