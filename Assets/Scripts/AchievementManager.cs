using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    public static AchievementManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockAchievement(Achievement achievement)
    {
        string key = "Achievement_" + achievement.ToString();
        if (PlayerPrefs.GetInt(key, 0) == 0) // not unlocked yet
        {
            PlayerPrefs.SetInt(key, 1);  // mark as unlocked
            PlayerPrefs.Save();
            Debug.Log("Achievement unlocked: " + achievement);

            // TODO: show UI popup, sound, particle effect, etc.
        }
    }

    public bool IsAchievementUnlocked(Achievement achievement)
    {
        string key = "Achievement_" + achievement.ToString();
        return PlayerPrefs.GetInt(key, 0) == 1;
    }
}

    