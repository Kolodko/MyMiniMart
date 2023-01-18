using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Product", fileName = "ObjProduct")]
public class ScriptableObjectProduct : ScriptableObject
{
    //Обьекты на грядках и на полках
    public List<GameObject> ProductSprout = new List<GameObject>();
    public List<GameObject> ProductShelf = new List<GameObject>();
    public int Count, Money = 40;
}