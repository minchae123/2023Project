using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoenyComb : MonoBehaviour
{
    public UnityEvent OnGetHoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnGetHoney?.Invoke();
        }
    }
}
