using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IntroManager : MonoBehaviour
{
    public static IntroManager Instance;
    private Image Background;
    private SpriteRenderer Logo;
    private float duration = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Background = GetComponentInChildren<Image>();
            Logo = GetComponentInChildren<SpriteRenderer>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Hide()
    {
        BackgroundFadeOut();
        Invoke("LogoFadeOut", duration * 2);
    }

    public void BackgroundFadeIn()
    {
        Background.DOFade(1, duration);
    }

    public void BackgroundFadeOut()
    {
        Background.DOFade(0, duration);
    }

    public void LogoFadeIn()
    {
        Logo.DOFade(1, duration);
    }

    public void LogoFadeOut()
    {
        Logo.DOFade(0, duration);
    }
}