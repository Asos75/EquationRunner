using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public string characterDescription;
    public Sprite characterIcon;
    public GameObject prefab;
    public Achievement unlockAchievement;
}
