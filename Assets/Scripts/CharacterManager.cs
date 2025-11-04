using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterData[] characters;
    public static CharacterManager Instance;
    public int selectedCharacterIndex = 0;

    public Transform playerParent;
    private GameObject currentCharacter;

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
        selectedCharacterIndex = GetSelectedCharacter();
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

    public void SpawnSelectedCharacter()
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        int index = GetSelectedCharacter();
        if (index < 0 || index >= characters.Length)
            index = 0;

        currentCharacter = Instantiate(characters[index].prefab, playerParent);

        currentCharacter.transform.localPosition = Vector3.zero;
        currentCharacter.transform.localRotation = Quaternion.identity;

        Debug.Log("Spawned character: " + characters[index].name);
    }
}
