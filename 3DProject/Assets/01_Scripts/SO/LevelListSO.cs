using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int level;
    public GameObject map;
}

[CreateAssetMenu(menuName ="SO/Level")]
public class LevelListSO : ScriptableObject
{
    public List<Level> list;
}