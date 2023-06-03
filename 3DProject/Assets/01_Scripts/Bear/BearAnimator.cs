using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimator : MonoBehaviour
{
    private Animator animator;
    public Animator Animator => animator;

    private int speedFloat = Animator.StringToHash("speed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk()
    {
        animator.SetFloat(speedFloat, 1);
        Debug.Log(speedFloat);
    }

    public void Idle()
    {
        animator.SetFloat(speedFloat, -1);
        Debug.Log(speedFloat);
    }
}
