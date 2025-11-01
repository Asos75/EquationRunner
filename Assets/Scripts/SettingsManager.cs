using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public AudioSource musicSource;

    [Header("Math Operations")]
    public Toggle addSubToggle;
    public Toggle mulDivToggle;

    [Header("Difficulty")]
    public TMP_Dropdown difficultyDropdown; // or TMP_Dropdown

    void Start()
    {
        LoadSettings();

        // Add listeners for auto-saving
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        difficultyDropdown.onValueChanged.AddListener(SetDifficulty);
        addSubToggle.onValueChanged.AddListener(delegate { SetOperations(); });
        mulDivToggle.onValueChanged.AddListener(delegate { SetOperations(); });
    }

    public void SetMusicVolume(float value)
    {
        if (musicSource != null)
            musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }

    public void SetDifficulty(int index)
    {
        PlayerPrefs.SetInt("Difficulty", index);
        PlayerPrefs.Save();
    }

    public void SetOperations()
    {
        PlayerPrefs.SetInt("AddSubEnabled", addSubToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("MulDivEnabled", mulDivToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.8f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
        int difficulty = PlayerPrefs.GetInt("Difficulty", 0);
        bool addSub = PlayerPrefs.GetInt("AddSubEnabled", 1) == 1;
        bool mulDiv = PlayerPrefs.GetInt("MulDivEnabled", 1) == 1;

        musicVolumeSlider.value = musicVol;
        sfxVolumeSlider.value = sfxVol;
        difficultyDropdown.value = difficulty;
        addSubToggle.isOn = addSub;
        mulDivToggle.isOn = mulDiv;

        if (musicSource != null)
            musicSource.volume = musicVol;
    }

    public void ReuturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
