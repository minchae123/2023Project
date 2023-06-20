using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UIManager.Instance.heartController.ReduceHeart(--GameManager.Instance.Heart);
        }

        if (other.CompareTag("Bee"))
        {
            other.GetComponent<Bee>().DieAnimation();
        }
    }
}