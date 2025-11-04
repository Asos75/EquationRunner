using UnityEngine;
using TMPro;
using System.Collections;

public class AchievementPopup : MonoBehaviour
{
    public float lifetime = 3f;
    public float fadeDuration = 0.5f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        yield return new WaitForSeconds(lifetime);

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = 1 - (elapsed / fadeDuration);
            yield return null;
        }

        Destroy(gameObject);
    }
}
