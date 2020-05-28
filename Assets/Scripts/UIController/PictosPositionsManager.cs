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

    public static void Position(string name)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(name))
        {
            // Debug.Log(name + " END");
            PictoLoadingManager.Loader();
            Image.DOFade(0, durationDisappear);
            Animator.ResetTrigger(name);
            Animator.SetTrigger("Default");
        }
        else
        {
            // Debug.Log(name + " START");
            PictoLoadingManager.Loader();
            Image.DOFade(1, durationAppear);
            Animator.SetTrigger(name);
            Animator.speed = 1;
        }
    }

    private void LateUpdate()
    {
        Image.SetNativeSize();
    }
}