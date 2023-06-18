using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] private bool isCanAttack = true;

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
            print("공격");
            isCanAttack = false;
            StartCoroutine(Delay(5));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (GameManager.Instance.Heart > 0)
                UIManager.Instance.heartController.ReduceHeart(--GameManager.Instance.Heart);
            else
                print("주금");
        }
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        isCanAttack = true;
    }
}
