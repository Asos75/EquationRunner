using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public GameObject characterItemPrefab;
    public Transform contentParent;

    void Start()
    {
        PopulateCharacters();
    }

    void PopulateCharacters()
    {
        foreach (var character in CharacterManager.Instance.characters)
        {
            GameObject item = Instantiate(characterItemPrefab, contentParent);

            var nameText = item.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            var descText = item.transform.Find("Desc").GetComponent<TextMeshProUGUI>();
            var button = item.GetComponentInChildren<Button>();
            var image = item.transform.Find("Icon").GetComponent<Image>();

            bool unlocked = AchievementManager.Instance.IsAchievementUnlocked(character.unlockAchievement);

            nameText.text = unlocked ? character.characterName : "Locked";
            descText.text = unlocked ? character.characterDescription : "Unlocked by " + character.unlockAchievement.ToString();

            image.sprite = character.characterIcon;

            button.interactable = unlocked;

            CharacterData capturedCharacter = character;

            button.onClick.AddListener(() =>
            {
                if (unlocked)
                {
                    CharacterManager.Instance.SelectCharacter(System.Array.IndexOf(CharacterManager.Instance.characters, capturedCharacter));
                    Debug.Log($"Selected character: {capturedCharacter.characterName}");
                }
            });
        }
    }
}
