using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBackgroundScript : MonoBehaviour
{
    public float fadeInDuration = 0.5f;

    public float startAlpha = 0f;
    public float endAlpha = 1f;

    private SpriteRenderer spriteRenderer;

    private Renderer objectRenderer;
    private Material material;
    private Color startColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
    }

    public void InstantChange()
    {
        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
    }

    public void FadeInOn()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeOutOn()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        Color color = spriteRenderer.color;
        color.a = 0f;

        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            color.a = alpha;
            spriteRenderer.color = color;

            elapsedTime = Time.time - startTime;

            yield return null;
        }

        color.a = 1f;
        spriteRenderer.color = color;
    }

    private IEnumerator FadeOut()
    {
        Color color = spriteRenderer.color;
        color.a = 1f;

        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeInDuration);
            color.a = alpha;
            spriteRenderer.color = color;

            elapsedTime = Time.time - startTime;

            yield return null;
        }

        color.a = 0f;
        spriteRenderer.color = color;
    }
}
