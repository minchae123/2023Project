using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimator : MonoBehaviour
{
    private Animator animator;
    public Animator Animator => animator;

    private int idleTrigger = Animator.StringToHash("idle");
    private int walkTrigger = Animator.StringToHash("is_walk");
    private int walkBool = Animator.StringToHash("walk");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool value)
    {
        animator.SetTrigger(walkTrigger);
        animator.SetBool(walkBool, value);
    }

    public void Idle()
    {
        animator.SetTrigger(idleTrigger);
    }
}
