using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public SceneLoad sceneLoad;

    [SerializeField] TextMeshProUGUI curLevelTxt;


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("UIManger 오류");
        }
        Instance = this;

        sceneLoad = GetComponentInChildren<SceneLoad>();
    }

    private void Update()
    {

    }

    public void SetLevelText(int level)
    {
        curLevelTxt.text = $"현재 레벨 : {level}";
    }
}
