using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoenyComb : MonoBehaviour
{
    public UnityEvent OnGetHoney;

    private void OnTriggerEnter(Collider other)
    {
        print('q');
        if (other.gameObject.tag == "Player")
        {
            print('p');
            OnGetHoney?.Invoke();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetEnemy()
    {
        GameManager.Instance.SpawnBee(transform.position);
    }
}
