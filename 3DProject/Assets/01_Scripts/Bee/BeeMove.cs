using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeMove : MonoBehaviour
{
    private SkinnedMeshRenderer meshRenderer;
    private Transform playerTrm;
    private NavMeshAgent nav;

    public float flySpeed = 5f;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        nav = GetComponent<NavMeshAgent>();
        playerTrm = GameObject.Find("Player").GetComponent<Transform>();

        StartCoroutine(Flying());
        StartCoroutine(MoveDelay());
    }

    private void Update()
    {
    }

    private IEnumerator Flying()
    {
        float fly = 0;
        while (true)
        {
            fly = Mathf.Sin(Time.time * flySpeed) * 50 + 50;
            meshRenderer.SetBlendShapeWeight(0, fly);
            yield return null;
        }
    }

    public void Move()
    {
        nav.SetDestination(playerTrm.position);
    }

    IEnumerator MoveDelay()
    {
        while (true)
        {
            Move();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
