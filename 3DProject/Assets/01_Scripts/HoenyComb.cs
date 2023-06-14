using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class HoenyComb : MonoBehaviour
{
    public UnityEvent OnGetHoney;
    public float moveSpeed;
    public float power;
    public float upScale;

    private BoxCollider col;

    private void Awake() 
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnGetHoney?.Invoke();
        }
    }

    private void Update()
    {
        Fluffy();
    }

    public void Fluffy()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * moveSpeed) * power + power, transform.position.z) + new Vector3(0, upScale, 0);
    }

    public void Destroy()
    {
        UIManager.Instance.RemainHoney(--GameManager.Instance.RemainHoney);
        col.enabled = false;
        Destroy(gameObject);
    }

    public void SetEnemy()
    {
        GameManager.Instance.SpawnBee(transform.position);
    }
}
