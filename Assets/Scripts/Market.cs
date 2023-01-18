using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class Market : MonoBehaviour
{
    [SerializeField] private ScriptableObjectProduct m_ScriptableObject;
    [SerializeField] private GameObject _object, _squae;

    public TextMeshProUGUI Text;
    public float x, y, z;
    
    private void Awake()
    {
        AnimationSquare();
        Text.text = m_ScriptableObject.Money.ToString();
    }

    //Анимация квадрата покупки
    private void AnimationSquare()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(0.396f, 0.396f, 0.396f), 0.3f));
        mySequence.Append(transform.DOScale(new Vector3(0.376f, 0.376f, 0.376f), 0.3f));
        mySequence.Play().SetLoops(-1);
    }

    //Анимация покупки новых построек
    private void OpenMarket()
    {
        _squae.SetActive(false);
        _object.SetActive(true);
        m_ScriptableObject.Money -= 20;
        Text.text = m_ScriptableObject.Money.ToString();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(_object.transform.DOScale(new Vector3(x, y, z), 0.7f));
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<PlayerController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.player)
        {
            OpenMarket();
        }
    }

}