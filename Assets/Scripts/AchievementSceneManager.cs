using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementSceneManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
