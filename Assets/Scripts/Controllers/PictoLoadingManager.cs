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

    public void LoaderInit()
    {
        Animator.SetBool("isLoaded", false);
        Animator.SetBool("isShowing", true);
        SpriteRenderer.DOFade(1, 2f);
        Invoke("LoaderLoading", 5.4f);
    }

    public void LoaderLoading()
    {
        Animator.SetBool("isShowing", false);
        Animator.SetBool("isLoading", true);
        Invoke("LoaderLoaded", 2.3f);
    }

    public void LoaderLoaded()
    {
        SpriteRenderer.DOFade(0, 0.2f);
        Animator.SetBool("isLoading", false);
        Animator.SetBool("isLoaded", true);
    }
}