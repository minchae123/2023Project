using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneLoad : MonoBehaviour
{
    private RectTransform rectTrm;
    private Image rectImage;
    private Vector2 screenSize;

    private void Awake()
    {
        rectTrm = GetComponent<RectTransform>();
        rectImage = GetComponent<Image>();
        screenSize = new Vector2(Screen.width / 2.5f, Screen.height / 2.5f);
        rectTrm.sizeDelta = screenSize;
    }

    public void LoadingOff()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(rectTrm.DOAnchorPosY(screenSize.y, 0.5f).SetEase(Ease.OutCubic));
        seq.Join(rectImage.DOFade(0, 0.5f));
    }

    public void LoadingOn()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(rectTrm.DOAnchorPosY(0, 0f).SetEase(Ease.InCubic));
        seq.Join(rectImage.DOFade(1, 0.5f));
    }
}
