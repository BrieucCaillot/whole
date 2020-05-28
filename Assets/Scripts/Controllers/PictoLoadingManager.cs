using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PictoLoadingManager : MonoBehaviour
{
    public static PictoLoadingManager Instance;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            SpriteRenderer.DOFade(0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("LoaderEnd"))
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= Animator.GetCurrentAnimatorStateInfo(0).length / 2)
            {
                Animator.ResetTrigger("LoaderEnd");
                SpriteRenderer.DOFade(0, 0.5f);
                Animator.SetTrigger("LoaderReset");
            }
        }
    }

    public void Loader()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("LoaderStart"))
        {
            Animator.ResetTrigger("LoaderStart");
            Animator.SetTrigger("LoaderEnd");
        }
        else
        {
            SpriteRenderer.DOFade(1, 1.5f);
            Animator.ResetTrigger("LoaderReset");
            Animator.SetTrigger("LoaderStart");
        }
    }
}