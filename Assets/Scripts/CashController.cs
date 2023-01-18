using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CashController : MonoBehaviour
{
    [SerializeField] private List<Transform> _productsPointsFinal = new List<Transform>();
    [SerializeField] private List<Transform> _productsPoints = new List<Transform>();
    [SerializeField] private List<GameObject> _products = new List<GameObject>();
    [SerializeField] private GameObject _box;

    private BuyersController _buyersController;
    private bool _player, _buyer, _test;

    //Продажа продуктов
    private void SaleOfProducts(Collider coll)
    {
        _buyersController = coll.GetComponent<BuyersController>();
        for (int i = 0; i < 3; i++)
        {
            _products[i] = coll.GetComponent<BuyersController>().Products[i];
            _products[i].GetComponent<ProductController>().Transform = false;
            _products[i].GetComponent<ProductController>()._point = _productsPoints[i];
        }
        StartCoroutine(EndPurchase());
    }

    //Анимация конца продажи продуктов
    IEnumerator EndPurchase()
    {
        yield return new WaitForSeconds(0.5f);
        Sequence mySequence = DOTween.Sequence();
        _box.SetActive(true);
        mySequence.Append(_box.transform.DOScale(new Vector3(0.02388f, 0.0382f, 0.02388f), 0.4f));
        mySequence.Append(_box.transform.DOScale(new Vector3(0.02378f, 0.0372f, 0.02378f), 0.2f));

        yield return new WaitForSeconds(0.6f);

        for (int i = 0; i < 3; i++)
        {
            _products[i].GetComponent<ProductController>().Transform = true;
            yield return new WaitForSeconds(0.4f);
            _products[i].GetComponent<ProductController>()._point = _productsPointsFinal[i];
            yield return new WaitForSeconds(0.4f);
            Destroy(_products[i]);
        }
        yield return new WaitForSeconds(0.4f);
        _box.transform.SetParent(_buyersController.transform);
        _box.transform.DOMove(_buyersController.PointBox.transform.position, 0.6f);
        yield return new WaitForSeconds(0.4f);
        _buyersController.GoTheExit();
    }

    //Проверка пришли игрок и покупатель к кассе
    private void OnTriggerStay(Collider coll)
    {
        if (coll.GetComponent<BuyersController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.buyers)
        {
            _buyer = true;
            if(_buyer && _player)
            {
                if (_test == false)
                {
                    _test = true;
                    SaleOfProducts(coll);
                }
            }
        }
        if (coll.GetComponent<PlayerController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.player)
        {
            _player = true;
        }
    }

    //Проверка ушли игрок и покупатель от кассы
    private void OnTriggerExit(Collider coll)
    {
        if (coll.GetComponent<BuyersController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.buyers)
        {
            _buyer = false;
        }
        if (coll.GetComponent<PlayerController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.player)
        {
            _player = false;
        }
    }
}