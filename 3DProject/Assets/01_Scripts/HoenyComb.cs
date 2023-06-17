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
        GameManager.Instance.RemainHoney--;
        UIManager.Instance.RemainHoney(GameManager.Instance.RemainHoney);
        col.enabled = false;
        StartCoroutine(Size(0.7f, 1));
        //Destroy(gameObject);
    }

    public void SetEnemy()
    {
        GameManager.Instance.SpawnBee();
    }

    public float EaseInOuQuad(float x) 
    {
        return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
    }

    IEnumerator Size(float t, float yDelta)
    {
        float percent = 0, currentT = 0;
        Vector3 firstSize = transform.localScale;

        while (percent < 1)
        {
            currentT += Time.deltaTime;
            percent = currentT / t;
            float value = EaseInOuQuad(percent);

            float v = yDelta * value;
            transform.localScale = firstSize + new Vector3(v, v, v);

            yield return null;
        }
    }
}
