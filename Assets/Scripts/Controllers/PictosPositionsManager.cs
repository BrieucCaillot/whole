using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PictosPositionsManager : MonoBehaviour
{
    public static PictosPositionsManager Instance;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;
    private float durationAppear = 2f;
    private float durationDisappear = 2f;

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

    public void Position(string name)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(name))
        {
            Debug.Log(name + " END");
            PictoLoadingManager.Instance.Loader();
            SpriteRenderer.DOFade(0, durationDisappear);
            Animator.ResetTrigger(name);
            Animator.SetTrigger("Default");
        }
        else
        {
            Debug.Log(name + " START");
            PictoLoadingManager.Instance.Loader();
            SpriteRenderer.DOFade(1, durationAppear);
            Animator.SetTrigger(name);
            Animator.speed = 1;
        }
    }
}