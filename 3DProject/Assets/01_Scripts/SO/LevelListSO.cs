using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Level")]
public class LevelListSO : ScriptableObject
{
    public List<GameObject> map;
}