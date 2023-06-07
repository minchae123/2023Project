using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int curLevel = 1;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("GameManager ¿À·ù");
        }
        Instance = this;
    }

    private void Update()
    {

    }


    public void LoadStage()
    {
        LevelManager.Instance.MapLoad(curLevel);

    }
}
