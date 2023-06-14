using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public int level;
    [SerializeField] private int honeyCnt;
    public int HoneyCnt => honeyCnt;
}
