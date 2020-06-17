using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PictosPositionsManager : Singleton<PictosPositionsManager>
{
    private static Image Image;
    private static Animator Animator;
    private static float durationAppear = 3f;
    private static float durationDisappear = 2f;

    private void Start()
    {
        Image = GetComponent<Image>();
        Animator = GetComponent<Animator>();
        Image.DOFade(0, 0);
    }

    public void ShowPicto(string name)
    {
        PictoLoadingManager.Loader();
        Image.DOFade(1, durationAppear);
        Animator.SetTrigger(name);
        Animator.speed = 1;
    }

    public void HidePicto()
    {
        PictoLoadingManager.Loader();
        Image.DOFade(0, durationDisappear);
        Animator.ResetTrigger(name);
        Animator.SetTrigger("Default");
    }

    private void LateUpdate()
    {
        Image.SetNativeSize();
    }
}