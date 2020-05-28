using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PictoLoadingManager : Singleton<PictoLoadingManager>
{
    private static Image Image;
    private static Animator Animator;

    private void Start()
    {
        Image = GetComponent<Image>();
        Animator = GetComponent<Animator>();
        Image.DOFade(0, 0);
    }

    private void Update()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("LoaderEnd"))
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= Animator.GetCurrentAnimatorStateInfo(0).length / 2)
            {
                Animator.ResetTrigger("LoaderEnd");
                Image.DOFade(0, 0.5f);
                Animator.SetTrigger("LoaderReset");
            }
        }
    }

    public static void Loader()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("LoaderStart"))
        {
            Animator.ResetTrigger("LoaderStart");
            Animator.SetTrigger("LoaderEnd");
        }
        else
        {
            Image.DOFade(1, 1.5f);
            Animator.ResetTrigger("LoaderReset");
            Animator.SetTrigger("LoaderStart");
        }
    }
}