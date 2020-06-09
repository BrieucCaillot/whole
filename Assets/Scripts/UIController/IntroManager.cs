using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IntroManager : MonoBehaviour
{
    public static IntroManager Instance;
    [SerializeField] private Image Background;
    [SerializeField] private SpriteRenderer Logo;
    private static float duration = 2f;

    public void Hide()
    {
        BackgroundFadeOut();
        LogoFadeOut();
    }

    private void BackgroundFadeIn()
    {
        Background.DOFade(1, duration);
    }

    private void BackgroundFadeOut()
    {
        Background.DOFade(0, duration).OnComplete(() => GameManager.Instance.IntroSceneCompleted());
    }

    private void LogoFadeIn()
    {
        Logo.DOFade(1, duration);
    }

    private void LogoFadeOut()
    {
        Logo.DOFade(0, duration);
    }
}