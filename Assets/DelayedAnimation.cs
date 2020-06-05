using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator playAnimation() {
        yield return new WaitForSeconds(Random.Range(-0.5f, 0.5f));
        // animator.Play("Fly", 0, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
