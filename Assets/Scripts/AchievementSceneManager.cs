using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementSceneManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu from Achievements Scene");
        SceneManager.LoadScene(0);
    }
}
