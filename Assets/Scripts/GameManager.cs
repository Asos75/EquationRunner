using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; } = 0;
    public int Health { get; private set; } = 100;

    public TMP_Text scoreText;
    public TMP_Text healthText;

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

    void UpdateUI()
    {
        scoreText.text = $"{Score}";
        healthText.text = $"{Health}";
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
    }
}
