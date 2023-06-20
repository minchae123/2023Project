using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public SceneLoad sceneLoad;
    public HeartController heartController;

    [SerializeField] private TextMeshProUGUI curLevelTxt;
    [SerializeField] private TextMeshProUGUI honeyCntTxt;
    [SerializeField] private TextMeshProUGUI curTimeTxt;

    public GameObject menuPanel;
    private bool isMenuOpen = false;
    public GameObject rePanel;
    public GameObject successPanel;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("UIManger 오류");
        }
        Instance = this;

        sceneLoad = GetComponentInChildren<SceneLoad>();
        heartController = GetComponentInChildren<HeartController>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f; 
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f; 
        isMenuOpen = false;
    }

    public void SetLevelText(int level)
    {
        curLevelTxt.text = $"현재 레벨 : {level}";
    }

    public void RemainHoney(int count)
    {
        honeyCntTxt.text = $"남은 꿀 : {count}";
    }

    public void TimerSet(int time)
    {
        curTimeTxt.text = $"남은 시간 : {time}";
    }

    public void OffPanel(GameObject panel)
    {
        panel.gameObject.SetActive(false);
    }

    public void OnPanel(GameObject panel)
    {
        panel.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("빠잉");
    }

    public void RestartGame()
    {
        GameManager.Instance.LoadStage(GameManager.Instance.CurLevel - 1);
        Time.timeScale = 1;
        rePanel.SetActive(false);
    }

    public void NextGame()
    {
        successPanel.SetActive(false);
        GameManager.Instance.LoadStage(GameManager.Instance.CurLevel);
        sceneLoad.LoadingOff();
        print("꺼졍");
    }
}