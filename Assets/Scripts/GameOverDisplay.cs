using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{

    public Image gameOverImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverImage.enabled = false;
    }

   public void ShowGameOver()
    {
        gameOverImage.enabled = true;
    }
}
