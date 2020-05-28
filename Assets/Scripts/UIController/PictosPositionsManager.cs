using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PictosPositionsManager : MonoBehaviour
{
    public static PictosPositionsManager Instance;
    private Image Image;
    private Animator Animator;
    private float durationAppear = 3f;
    private float durationDisappear = 2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Image = GetComponent<Image>();
            Animator = GetComponent<Animator>();
            Image.DOFade(0, 0);
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
            Image.DOFade(0, durationDisappear);
            Animator.ResetTrigger(name);
            Animator.SetTrigger("Default");
        }
        else
        {
            Debug.Log(name + " START");
            PictoLoadingManager.Instance.Loader();
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