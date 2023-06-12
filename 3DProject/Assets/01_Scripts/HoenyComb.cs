using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoenyComb : MonoBehaviour
{
    public UnityEvent OnGetHoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnGetHoney?.Invoke();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject, 3f);
    }

    public void SetEnemy()
    {
        GameManager.Instance.SpawnBee(transform.position);
    }
}
