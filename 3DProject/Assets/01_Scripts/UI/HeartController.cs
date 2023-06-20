using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Image[] hearts;

    public void FullHeart()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

    public void ReduceHeart(int index)
    {
        if (index < hearts.Length)
            hearts[index].gameObject.SetActive(false);
        else
            print("аж╠щ");
    }
}