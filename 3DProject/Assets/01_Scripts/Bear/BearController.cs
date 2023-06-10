using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    private BearAnimator animator;
    public BearAnimator Animator => animator;

    private void Awake()
    {
        animator = transform.Find("Model").GetComponent<BearAnimator>();
    }

}
