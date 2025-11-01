using UnityEngine;

public class AchievementScrollPopulator : MonoBehaviour
{
    public GameObject achievementPrefab;  
    public Transform contentParent;       

    void Start()
    {
        PopulateAchievements();
    }

    void PopulateAchievements()
    {
        foreach (Achievement achievement in System.Enum.GetValues(typeof(Achievement)))
        {
            GameObject item = Instantiate(achievementPrefab, contentParent);
            var ui = item.GetComponent<AchievementItemUI>();
            ui.SetAchievement(achievement);
        }
    }
}
