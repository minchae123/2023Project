using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private LevelListSO levelSO;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("LevelManager ����");
        }
        Instance = this;
    }

    public void MapLoad(int level)
    {
        if(level > 0 && level < 6){
            Instantiate(levelSO.map[level-1], new Vector3(0, -1.26f, 0), Quaternion.identity);
            Debug.Log(level);
        }
    }
}
