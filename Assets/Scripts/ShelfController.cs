using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    private BuyersController buyersController;
    private bool Player;

    public List<GameObject> Products = new List<GameObject>();
    public List<Transform> Points = new List<Transform>();

    public int CountShelf;
    public bool tester;

    //Проверка что пришел покупатель чтобы забрать продукты с полки
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<PlayerController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.player)
            StartCoroutine(StartBuyersPosition());
    }


    //Проверка что пришел игрок чтобы принести продукты на полку
    private void OnTriggerStay(Collider coll)
    {
        if (coll.GetComponent<BuyersController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.buyers)
        {
            if (Player && tester == false)
            {
                tester = true;
                for (int i = CountShelf - 3; i < CountShelf; i++)
                {
                    buyersController = coll.GetComponent<BuyersController>();
                    buyersController.Products[i] = Products[i];
                }
                buyersController.GoTheСheckout();
            }
        }
    }

    IEnumerator StartBuyersPosition()
    {
        yield return new WaitForSeconds(0.8f);
        Player = true;
    }
}