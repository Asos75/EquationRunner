using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItemUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public CanvasGroup canvasGroup; // for transparency

    public void SetAchievement(Achievement achievement)
    {
        var info = AchievementText.Info[achievement];
        titleText.text = info.Name;
        descriptionText.text = info.Description;

        // Check if unlocked
        bool unlocked = AchievementManager.Instance.IsAchievementUnlocked(achievement);

        if (unlocked)
        {
            // Fully visible
            canvasGroup.alpha = 1f;
        }
        else
        {
            // Transparent / faded
            canvasGroup.alpha = 0.4f;
        }
    }
}
