using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingWings : MonoBehaviour
{
    private SkinnedMeshRenderer meshRenderer;
    public float flySpeed = 5f;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        StartCoroutine(Flying());
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
}
