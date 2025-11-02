using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public GameObject characterItemPrefab;
    public Transform contentParent;

    public Color selectedColor = new Color(0.6f, 1f, 0.6f, 1f); // light green tint

    void Start()
    {
        PopulateCharacters();
    }

    void PopulateCharacters()
    {
        for (int i = 0; i < CharacterManager.Instance.characters.Length; i++)
        {
            CharacterData character = CharacterManager.Instance.characters[i];
            GameObject item = Instantiate(characterItemPrefab, contentParent);

            // Get UI elements
            var nameText = item.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            var descText = item.transform.Find("Desc").GetComponent<TextMeshProUGUI>();
            var iconImage = item.transform.Find("Icon").GetComponent<Image>();
            var button = item.GetComponentInChildren<Button>();
            var panelImage = item.GetComponent<Image>();
            var canvasGroup = item.GetComponent<CanvasGroup>() ?? item.AddComponent<CanvasGroup>();

            bool unlocked = AchievementManager.Instance.IsAchievementUnlocked(character.unlockAchievement);
            bool selected = CharacterManager.Instance.GetSelectedCharacter() == i;

            // Set text
            nameText.text = unlocked ? character.characterName : "Locked";
            descText.text = unlocked ? character.characterDescription : "Unlock via: " + character.unlockAchievement.ToString();

            // Icon grayscale if locked
            iconImage.sprite = character.characterIcon;
            iconImage.color = unlocked ? Color.white : new Color(0.5f, 0.5f, 0.5f, 1f);

            // Canvas alpha for locked, fully opaque for selected
            canvasGroup.alpha = unlocked ? 1f : 0.4f;

            // Panel color tint for selected
            panelImage.color = selected ? selectedColor : Color.white;

            // Button interactable only if unlocked
            button.interactable = unlocked;

            int capturedIndex = i;
            button.onClick.AddListener(() =>
            {
                if (unlocked)
                {
                    CharacterManager.Instance.SelectCharacter(capturedIndex);
                    UpdateSelectionHighlights();
                    Debug.Log($"Selected character: {character.characterName}");
                }
            });
        }
    }

    void UpdateSelectionHighlights()
    {
        for (int i = 0; i < contentParent.childCount; i++)
        {
            Transform child = contentParent.GetChild(i);
            var panelImage = child.GetComponent<Image>();
            int selectedIndex = CharacterManager.Instance.GetSelectedCharacter();
            panelImage.color = (i == selectedIndex) ? new Color(0.6f, 1f, 0.6f, 1f) : Color.white;
        }
    }
}
