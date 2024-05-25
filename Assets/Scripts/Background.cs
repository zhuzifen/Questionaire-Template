using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Background : MonoBehaviour
{
    [SerializeField] Image backgroundImage;
    [SerializeField] List<BackgroundSO> backgrounds = new List<BackgroundSO>();
    int currentBackgroundIndex = 0;
    BackgroundSO currentBackground;
    void Start()
    {
        currentBackground = backgrounds[0];
        backgroundImage.sprite = currentBackground.GetImage();
    }
    public void OnAnswerSelected() {
        StartCoroutine(FadeChangeBackground());
    }

    IEnumerator FadeChangeBackground()
    {
        yield return StartCoroutine(FadeImageTo(0.0f));

        currentBackgroundIndex++;
        currentBackground = backgrounds[currentBackgroundIndex];
        backgroundImage.sprite = currentBackground.GetImage();

        yield return StartCoroutine(FadeImageTo(0.4f));
    }

    IEnumerator FadeImageTo(float targetAlpha)
    {
        float alpha = backgroundImage.color.a;
        float duration = 0.5f; 
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(alpha, targetAlpha, time / duration);
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, newAlpha);
            yield return null;
        }
    }
}
