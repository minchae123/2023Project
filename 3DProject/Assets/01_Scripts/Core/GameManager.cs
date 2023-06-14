using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public GameObject Bee;

    private int curLevel = 1;
    private int remainHoney = 0;
    public int RemainHoney{ get =>remainHoney; set => remainHoney = value;}
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("GameManager 오류");
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
            print(m);
            if (m != null)
            {
                Destroy(m.gameObject);
            }

            player.transform.position = new Vector3(0, 10, 0);
            LevelManager.Instance.MapLoad(level);
            UIManager.Instance.SetLevelText(level);
            m = FindObjectOfType<MapInfo>();
            if(m != null)
            {
                remainHoney = m.HoneyCnt;
                UIManager.Instance.RemainHoney(remainHoney);
            }
            curLevel++;
        }
    }

    public void SpawnBee(Vector3 dir)
    {
        Instantiate(Bee, dir, Quaternion.identity);
    }
}
