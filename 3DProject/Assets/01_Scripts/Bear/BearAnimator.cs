using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimator : MonoBehaviour
{
    private Animator animator;
    public Animator Animator => animator;

    private readonly int speedFloat = Animator.StringToHash("speed");
    private readonly int clapbool = Animator.StringToHash("clap");
    private readonly int diebool = Animator.StringToHash("die");

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

    public void SetClap()
    {
        animator.SetBool(clapbool, true);
    }

    public void SetDie()
    {
        animator.SetBool(diebool, true);
    }

    public void SetClapStop()
    {
        animator.SetBool(clapbool, false);
    }

    public void SetDieStop()
    {
        animator.SetBool(diebool, false);
    }
}
