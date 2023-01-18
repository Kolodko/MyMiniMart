using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteText;

    public Transform[] Points;
    public int Count;

    //Анимация появления текста на игроком 
    public void TextAnimation(bool open)
    {
        if (open)
            _spriteText.DOFade(1f, 0.7f);
        else
            _spriteText.DOFade(0f, 0.7f);
    }
}