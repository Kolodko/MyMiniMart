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

    //�������� ��� ������ ���������� ����� ������� �������� � �����
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<PlayerController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.player)
            StartCoroutine(StartBuyersPosition());
    }


    //�������� ��� ������ ����� ����� �������� �������� �� �����
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
                buyersController.GoThe�heckout();
            }
        }
    }

    IEnumerator StartBuyersPosition()
    {
        yield return new WaitForSeconds(0.8f);
        Player = true;
    }
}