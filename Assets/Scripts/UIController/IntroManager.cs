using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IntroManager : Singleton<IntroManager>
{
    public static IntroManager Instance;
    private static Image Background;
    private static SpriteRenderer Logo;
    private static float duration = 2f;

    private void Start()
    {
        Background = GetComponentInChildren<Image>();
        Logo = GetComponentInChildren<SpriteRenderer>();
    }

    public static void Hide()
    {
        BackgroundFadeOut();
        LogoFadeOut();
    }

    public static void BackgroundFadeIn()
    {
        Background.DOFade(1, duration);
    }

    public static void BackgroundFadeOut()
    {
        Background.DOFade(0, duration);
    }

    public static void LogoFadeIn()
    {
        Logo.DOFade(1, duration);
    }

    public static void LogoFadeOut()
    {
        Logo.DOFade(0, duration);
    }
}