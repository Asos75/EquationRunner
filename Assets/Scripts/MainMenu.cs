using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource clickSFX;

    private void Awake()
    {
        clickSFX = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        AudioClip clickClip = Resources.Load<AudioClip>("Sound/Effects/click");
        clickSFX.clip = clickClip;
        clickSFX.volume = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
        clickSFX.Play();
    }

    public void PlayGame()
    {
        Debug.Log("Play Game button clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked");
        SceneManager.LoadScene(2);

    }

    public void OpenAchievements()
    {
        Debug.Log("Achievements button clicked");
        SceneManager.LoadScene(3);
    }

    public void OpenCharacterSelection()
    {
        Debug.Log("Character Selection button clicked");
        SceneManager.LoadScene(4);
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
