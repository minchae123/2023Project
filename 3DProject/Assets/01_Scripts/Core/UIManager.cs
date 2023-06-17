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

    }

    public void SetLevelText(int level)
    {
        curLevelTxt.text = $"현재 레벨 : {level}";
    }

    public void RemainHoney(int count)
    {
        honeyCntTxt.text = $"남은 꿀 : {count}";
    }
}
