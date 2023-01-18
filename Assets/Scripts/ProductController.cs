using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ProductController : MonoBehaviour
{
    [SerializeField] private ScriptableObjectProduct _scriptable;
    [SerializeField] public Transform _point;
    [SerializeField] public GameObject _object;

    private PlayerController player;

    public SproutController Sprout;
    public bool PickedUp, Transform, test;
    public float speed;

    //Перемещение продуктов
    private void Update()
    {
        if (Transform)
        {
            transform.SetParent(_point);
            transform.position += (_point.position - transform.position).normalized * speed * Time.deltaTime;
        }
    }

    //Перемещение продуктов к игроку
    private void MovingPlayer(Collider coll)
    {
        player = coll.GetComponent<PlayerController>();
        if (player.Count < 3)
        {
            Sprout.ProductCount -= 1;
            Sprout.StartCultivation();
            _point = player.Points[player.Count];
            _scriptable.ProductShelf.Add(_scriptable.ProductSprout[player.Count]);
            _scriptable.ProductSprout.RemoveAt(player.Count);
            player.Count++;
            _scriptable.Count--;
            Transform = true;
        }
        if (player.Count > 2)
            player.TextAnimation(true);
    }

    //Перемещение продуктов к полке
    private void MovingShelf(Collider coll)
    {
        speed = 5.5f;
        _point = coll.GetComponent<ShelfController>().Points[coll.GetComponent<ShelfController>().CountShelf];
        player.Count -= 1;
        coll.GetComponent<ShelfController>().Products[coll.GetComponent<ShelfController>().CountShelf] = _object;
        coll.GetComponent<ShelfController>().CountShelf++;
        player.TextAnimation(false);
        Transform = true;
    }

    //Проверка что игрок собирает продукты
    private void OnTriggerStay(Collider coll)
    {
        if (coll.GetComponent<PlayerController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.player)
        {
            if (PickedUp == false)
            {
                MovingPlayer(coll);
                PickedUp = true;
            }
        }
        if (coll.GetComponent<ShelfController>() != null && coll.GetComponent<EnumController>().enums == EnumController.Enums.shelh)
        {
            if (test == false)
            {
                MovingShelf(coll);
                test = true;
            }
        }
    }
}