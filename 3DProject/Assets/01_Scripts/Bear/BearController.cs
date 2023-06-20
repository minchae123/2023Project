using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    private BearAnimator animator;
    public BearAnimator Animator => animator;

    private BearMovement movement;
    public BearMovement Movement => movement;

    private AudioSource audioSource;
    public AudioSource AudioSource => audioSource;
    public AudioClip hitClip;

    private void Awake()
    {
        animator = transform.Find("Model").GetComponent<BearAnimator>();
        movement = GetComponent<BearMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Spawn();
        }
    }

    public void Die()
    {
        movement.StopPlayer();
        animator.SetDie();
    }

    public void Spawn()
    {
        animator.SetDieStop();
        animator.SetClapStop();
    }
}
