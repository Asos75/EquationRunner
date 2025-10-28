using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play Game button clicked");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked");

    }

    public void OpenAchievements()
    {
        Debug.Log("Achievements button clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game button clicked");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
