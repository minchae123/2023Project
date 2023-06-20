using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private bool delay = true;

    [SerializeField] private CinemachineVirtualCamera clearCam;
    private AudioSource audioSource;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("GameManager 오류");
        }
        Instance = this;

        audioSource = GetComponent<AudioSource>();
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
            SuccessLevel(); 
        }

        if(heart <= 0)
        {
            FailLevel();
            print("오버");
        }

        Timer();

        if(timer < 0)
        {
            FailLevel();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            FailLevel();
        }
    }

    public void Timer()
    {
        timer -= Time.deltaTime;
        UIManager.Instance.TimerSet((int)timer);
    }

    public void SuccessLevel()
    {
        if (delay)
        {
            delay = false;
            DestroyBee();
            clearCam.Priority = 15;
            timer += Time.deltaTime;
            player.GetComponentInChildren<BearAnimator>().SetClap();
            player.GetComponent<BearMovement>().StopPlayer();

            StartCoroutine(SucessDelay());
        }
    }

    IEnumerator SucessDelay()
    {
        yield return new WaitForSeconds(3);
        UIManager.Instance.OnPanel(UIManager.Instance.successPanel);
        //UIManager.Instance.sceneLoad.LoadingOn();
    }

    public void FailLevel()
    {
        //UIManager.Instance.sceneLoad.LoadingOn();
        DestroyBee();

        UIManager.Instance.rePanel.SetActive(true);
        player.GetComponent<BearController>().Die();
        timer += Time.deltaTime;
    }

    public void LoadStage(int level)
    {
        if(level > 0 && level < 6)
        {
            //UIManager.Instance.sceneLoad.LoadingOff();
            clearCam.Priority = 5;

            MapInfo m = FindObjectOfType<MapInfo>();
            if (m != null)
            {
                Destroy(m.gameObject);
            }
            
            LevelManager.Instance.MapLoad(level);

            m = FindObjectOfType<MapInfo>();
            if (m != null)
            {
                remainHoney = m.HoneyCnt;
                UIManager.Instance.RemainHoney(remainHoney);
            }

            player.GetComponent<BearMovement>().controller.Move(Vector3.zero + Vector3.up * 5);
            StartCoroutine(DelayLevel(level));
        }
        else if(level > 6)
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator DelayLevel(int level)
    {
        //player.transform.position = new Vector3(0, 10, 0);
        player.GetComponent<BearMovement>().StopPlayer();
        player.GetComponent<BearController>().Spawn();
        UIManager.Instance.heartController.FullHeart();
        UIManager.Instance.SetLevelText(level);
        delay = true;

        heart = 3;
        timer = 102;
        curLevel++;

        curLevel = Mathf.Clamp(curLevel, 0, 6);

        yield return new WaitForSeconds(2);
        player.GetComponent<BearMovement>().ResetPlayer();
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
