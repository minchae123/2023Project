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
            Debug.LogError("GameManager ¿À·ù");
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
            curLevel++;
            curLevel = Mathf.Clamp(curLevel, 1, 5);
        }
    }


    public void LoadStage(int level)
    {
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
