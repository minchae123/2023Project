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
            transform.position = transform.forward * 1f;
        }
    }

}
