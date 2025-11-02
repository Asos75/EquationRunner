using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    public int selectedCharacterIndex = 0;

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

    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;
        PlayerPrefs.SetInt("SelectedCharacter", index);
        PlayerPrefs.Save();
    }

    public int GetSelectedCharacter()
    {
        return PlayerPrefs.GetInt("SelectedCharacter", 0);
    }
}
