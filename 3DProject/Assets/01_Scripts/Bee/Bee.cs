using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] private bool isCanAttack = true;
    [SerializeField] private bool isCanHit = true;

    private Animator animator;

    private Material mat;

    private void Awake()
    {
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }

    public bool IsRange()
    {
        if(Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) < 1.5f)
        {
            return true;
        }
        return false;
    }

    public void Attack()
    {
        if(isCanAttack && IsRange())
        {
            isCanAttack = false;
            Material(Color.red);
            StartCoroutine(Delay(5));
        }
    }

    public void Material(Color c)
    {
        mat.color = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (GameManager.Instance.Heart > 0 && isCanHit)
            {
                isCanHit = false;
                UIManager.Instance.heartController.ReduceHeart(--GameManager.Instance.Heart);
                StartCoroutine(Delay2(2));
            }
            else
            {

            }
        }
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        isCanAttack = true;
        Material(Color.white);
    }

    IEnumerator Delay2(float t)
    {
        yield return new WaitForSeconds(t);
        isCanHit = true;    
    }

    public void DieAnimation()
    {
        StopAllCoroutines();
        animator.SetBool("die", true);
    }
}
