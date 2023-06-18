using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public GameObject Bee;

    private int curLevel = 1;
    public int CurLevel { get => curLevel; set => curLevel = value; }
    private int remainHoney = 0;
    public int RemainHoney{ get =>remainHoney; set => remainHoney = value;}

    private float timer = 100;

    private int heart = 3;
    public int Heart { get => heart; set => heart = value;}

    [SerializeField] private CinemachineVirtualCamera clearCam;

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
        }

        if(remainHoney <= 0)
        {
            SucessLevel(); 
        }

        if(heart <= 0)
        {
            player.GetComponent<BearController>().Die();
            print("오버");
        }

        timer -= Time.deltaTime;
        UIManager.Instance.TimerSet((int)timer);

        if(timer < 0)
        {
            FailLevel();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            FailLevel();
        }
    }

    public void SucessLevel()
    {
        DestroyBee();
        clearCam.Priority = 15;
        player.GetComponentInChildren<BearAnimator>().SetClap();
    }

    public void FailLevel()
    {
        UIManager.Instance.rePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadStage(int level)
    {
        if(level > 0 && level < 6)
        {
            MapInfo m = FindObjectOfType<MapInfo>();
            if (m != null)
            {
                Destroy(m.gameObject);
            }

            UIManager.Instance.sceneLoad.LoadingOff();
            
            LevelManager.Instance.MapLoad(level);

            m = FindObjectOfType<MapInfo>();
            if (m != null)
            {
                remainHoney = m.HoneyCnt;
                UIManager.Instance.RemainHoney(remainHoney);
            }

            StartCoroutine(DelayLevel(level));
        }
    }

    IEnumerator DelayLevel(int level)
    {
        player.transform.position = new Vector3(0, 10, 0);
        player.GetComponentInChildren<BearAnimator>().SetIdle();
        UIManager.Instance.heartController.FullHeart();
        UIManager.Instance.SetLevelText(level);

        heart = 3;
        timer = 102;
        curLevel++;

        yield return null;
    }

    public void SpawnBee()
    {
        GameObject b = Instantiate(Bee, transform.position, Quaternion.identity);
        b.transform.parent = gameObject.transform;
    }

    public void DestroyBee()
    {
        Bee[] bee = GetComponentsInChildren<Bee>();
        for(int i = 0; i < bee.Length; i++)
        {
            Destroy(bee[i].gameObject);
        }
    }

    public IEnumerator ChangeDealy()
    {
        yield return new WaitForSeconds(3);
        LoadStage(curLevel);
    }
}
