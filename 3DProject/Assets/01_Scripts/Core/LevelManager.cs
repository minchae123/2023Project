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
            Debug.LogError("LevelManager 오류");
        }
        Instance = this;
    }

    public void MapLoad(int level)
    {
        if(level > 0 && level < 6){
            Instantiate(levelSO.map[level - 1], transform.position, Quaternion.identity);
            //Debug.Log(level);
        }
    }
}
