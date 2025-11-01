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

    private bool addSubEnabled = true;
    private bool mulDivEnabled = false;

    private bool isGameOver = false;

    // Achievement tracking variables
    private int correctInRow = 0;
    private int correctAddSubInRow = 0;
    private int correctMulDivInRow = 0;
    private int totalCorrectAddSub = 0;
    private int totalCorrectMulDiv = 0;
    private int scoreFromAddSub = 0;
    private int scoreFromMulDiv = 0;
    private int gatesPassedWithoutHitting = 0;
    private bool hasIncorrectAnswer = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        addSubEnabled = PlayerPrefs.GetInt("AddSubEnabled", 1) == 1;
        mulDivEnabled = PlayerPrefs.GetInt("MulDivEnabled", 1) == 1;
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
        CheckScoreAchievements();
        OnCorrectAnswer(addSubEnabled, mulDivEnabled);
    }

    public void OnCorrectAnswer(bool isAddSub, bool isMulDiv)
    {
        
        correctInRow++;
        gatesPassedWithoutHitting++;
        
        bool isAddSubCategory = isAddSub;
        
        if (addSubEnabled && !mulDivEnabled)
        {
            isAddSubCategory = true;
        }
        else if (!addSubEnabled && mulDivEnabled)
        {
            isAddSubCategory = false;
        }
        
        if (isAddSubCategory)
        {
            correctAddSubInRow++;
            correctMulDivInRow = 0;
            totalCorrectAddSub++;
            scoreFromAddSub++;
            CheckAddSubAchievements();
        }
        else
        {
            correctMulDivInRow++;
            correctAddSubInRow = 0;
            totalCorrectMulDiv++;
            scoreFromMulDiv++;
            CheckMulDivAchievements();
        }
        
        CheckStreakAchievements();
        CheckGateAchievements();
    }

    public void OnIncorrectAnswer()
    {
        ReduceHealth(50);
        
        // Reset streaks
        correctInRow = 0;
        correctAddSubInRow = 0;
        correctMulDivInRow = 0;
        
        // First incorrect answer achievement
        if (!hasIncorrectAnswer)
        {
            hasIncorrectAnswer = true;
            AchievementManager.Instance?.UnlockAchievement(Achievement.FirstIncorrectAnswer);
        }
    }

    public void OnGateFrameHit()
    {
        SetHealth(0);
        
        // Reset gate counter
        gatesPassedWithoutHitting = 0;
        
        // Reset streaks
        correctInRow = 0;
        correctAddSubInRow = 0;
        correctMulDivInRow = 0;
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

    // Achievement checking methods
    private void CheckScoreAchievements()
    {
        if (Score >= 10)
            AchievementManager.Instance?.UnlockAchievement(Achievement.First10Points);
        if (Score >= 25)
            AchievementManager.Instance?.UnlockAchievement(Achievement.First25Points);
        if (Score >= 50)
            AchievementManager.Instance?.UnlockAchievement(Achievement.First50Points);
        if (Score >= 100)
            AchievementManager.Instance?.UnlockAchievement(Achievement.First100Points);
        if (Score >= 200)
            AchievementManager.Instance?.UnlockAchievement(Achievement.Score200Points);
        if (Score >= 500)
            AchievementManager.Instance?.UnlockAchievement(Achievement.Score500Points);
    }

    private void CheckAddSubAchievements()
    {
        if (totalCorrectAddSub >= 1)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FirstCorrectAddSub);
        if (correctAddSubInRow >= 5)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FiveCorrectAddSubInRow);
        if (correctAddSubInRow >= 10)
            AchievementManager.Instance?.UnlockAchievement(Achievement.TenCorrectAddSubInRow);
        if (scoreFromAddSub >= 20)
            AchievementManager.Instance?.UnlockAchievement(Achievement.TwentyPointsAddSub);
        if (totalCorrectAddSub >= 50)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FiftyEquationsAddSub);
    }

    private void CheckMulDivAchievements()
    {
        if (totalCorrectMulDiv >= 1)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FirstCorrectMulDiv);
        if (correctMulDivInRow >= 3)
            AchievementManager.Instance?.UnlockAchievement(Achievement.ThreeCorrectMulDivInRow);
        if (correctMulDivInRow >= 5)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FiveCorrectMulDivInRow);
        if (scoreFromMulDiv >= 20)
            AchievementManager.Instance?.UnlockAchievement(Achievement.TwentyPointsMulDiv);
        if (totalCorrectMulDiv >= 50)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FiftyEquationsMulDiv);
    }

    private void CheckStreakAchievements()
    {
        if (correctInRow >= 3)
            AchievementManager.Instance?.UnlockAchievement(Achievement.ThreeCorrectInRow);
        if (correctInRow >= 5)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FiveCorrectInRow);
        if (correctInRow >= 10)
            AchievementManager.Instance?.UnlockAchievement(Achievement.TenCorrectInRow);
        if (correctInRow >= 20)
            AchievementManager.Instance?.UnlockAchievement(Achievement.TwentyCorrectInRow);
        if (correctInRow >= 50)
            AchievementManager.Instance?.UnlockAchievement(Achievement.FiftyCorrectInRow);
    }



    private void CheckGateAchievements()
    {
        if (gatesPassedWithoutHitting >= 10)
        {
            AchievementManager.Instance?.UnlockAchievement(Achievement.TenGatesWithoutHitting);
        }
    }
}
