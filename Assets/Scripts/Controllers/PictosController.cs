using System;
using DG.Tweening;
using UnityEngine;

public class PictosController : MonoBehaviour
{
    public static PictosController Instance;
    public GameObject Loader;
    private SpriteRenderer SpriteRenderer;

    private Animator Animator;

    // public Sprite newSprite;
    private float duration = 3f;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}