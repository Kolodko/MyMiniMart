using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ScriptableObjectController : MonoBehaviour
{
    public ScriptableObjectProduct Scriptable;
    public static ScriptableObjectController Instance;

    //ScriptableObject ����� ����� ��� ����� ������ ������ ������ � ������ ��������
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }
}