using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimator : MonoBehaviour
{
    private Animator animator;
    public Animator Animator => animator;

    private readonly int speedFloat = Animator.StringToHash("speed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalk()
    {
        animator.SetFloat(speedFloat, 1);
    }

    public void SetIdle()
    {
        animator.SetFloat(speedFloat, 0);
    }
}
