using TMPro;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    public static AchievementManager Instance;
    public Transform popupParent;
    public GameObject achievementPopupPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

            if (popupParent.childCount > 0)
            {
                for (int i = 0; i < popupParent.childCount; i++)
                {
                    Destroy(popupParent.GetChild(i).gameObject);
                }
            }

            // Show popup
            GameObject popup = Instantiate(achievementPopupPrefab, popupParent);
            var name = popup.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            name.text = AchievementText.Info[achievement].Name;

        }
    }

    public bool IsAchievementUnlocked(Achievement achievement)
    {
        string key = "Achievement_" + achievement.ToString();
        return PlayerPrefs.GetInt(key, 0) == 1;
    }
}

    