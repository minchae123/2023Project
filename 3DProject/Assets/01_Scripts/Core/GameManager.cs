using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;

    private int curLevel = 1;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("GameManager ����");
        }
        Instance = this;
    }

    private void Start()
    {
        LoadStage(curLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadStage(curLevel);
            print(curLevel);
        }
    }


    public void LoadStage(int level)
    {
        if(level > 0 && level < 6){
            MapInfo m = FindObjectOfType<MapInfo>();

            if (m != null)
            {
                Destroy(m.gameObject);
            }

            player.transform.position = new Vector3(0, 10, 0);
            LevelManager.Instance.MapLoad(level);
            UIManager.Instance.SetLevelText(level);
            curLevel++;
        }
    }
}
