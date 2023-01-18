using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    //Очистка ScriptableObject
    private void OnApplicationQuit()
    {
        ScriptableObjectController.Instance.Scriptable.ProductSprout.Clear();
        ScriptableObjectController.Instance.Scriptable.ProductShelf.Clear();
        ScriptableObjectController.Instance.Scriptable.Count = 0;
        ScriptableObjectController.Instance.Scriptable.Money = 40;
    }
}