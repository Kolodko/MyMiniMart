using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SproutController : MonoBehaviour
{
    [SerializeField] private Transform[] _growingPoints;
    [SerializeField] private SproutController _sprout;
    [SerializeField] private GameObject _product;

    public int ProductCount;

    private void Awake()
    {
        StartCultivation();
    }

    public void StartCultivation()
    {
        StartCoroutine(Cultivation());
    }

    //Старт выращивания овощей
    IEnumerator Cultivation()
    {
        if (ProductCount == 0)
        {
            CultivationAnimation();
            for (int i = 0; i < _growingPoints.Length; i++)
            {
                yield return new WaitForSeconds(0.8f);
                ScriptableObjectProduct scriptable = ScriptableObjectController.Instance.Scriptable;
                GameObject Product = Instantiate(_product, transform.position, transform.rotation);
                ProductCount++;

                Product.transform.SetParent(_growingPoints[i]);
                Product.transform.DOMove(_growingPoints[i].transform.position, 0.8f);

                scriptable.ProductSprout.Add(Product);
                scriptable.ProductSprout[scriptable.Count].GetComponent<ProductController>().Sprout = _sprout;
                scriptable.Count++;
            }
        }
        else
        DOTween.KillAll();
    }

    //Анимация выращивания овощей
    private void CultivationAnimation()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(2.49f, 1.59f, 1.85f), 0.4f));
        mySequence.Append(transform.DOScale(new Vector3(2.3f, 1.45f, 2.11f), 0.4f));
        mySequence.Play().SetLoops(4);
    }
}