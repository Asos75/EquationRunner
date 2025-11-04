using UnityEngine;

public class CharacterSceneManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
