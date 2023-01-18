using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class BuyersController : MonoBehaviour
{
    [SerializeField] private Transform _dotShelf, _dot�heckout, _dotExit;
    [SerializeField] private GameObject Buyer;

    private NavMeshAgent _myAgent;
    private Animator _animator;

    public GameObject[] Products;
    public Transform[] Points;
    public Transform PointBox;
    public int Count;

    private void Awake()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        GoTheShelf();
    }

    //������������ �������� �� ����� ��������
    private void Update()
    {
        if (_myAgent.remainingDistance < 0.5f)
            _animator.SetTrigger("Idle");
        else
            _animator.SetTrigger("Run");
    }

    //������������ � �����
    private void GoTheShelf()
    { 
        _myAgent.SetDestination(_dotShelf.transform.position);
    }

    //������������ � �����
    public void GoThe�heckout()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i);
            Products[i].GetComponent<ProductController>()._point = Points[i];
            Products[i].GetComponent<ProductController>().Transform = false;
            Products[i].transform.SetParent(Points[i]);
            Products[i].transform.position = Points[i].transform.position;
        }
        _myAgent.SetDestination(_dot�heckout.transform.position);
    }

    //������������ � ������
    public void GoTheExit()
    {
        _myAgent.SetDestination(_dotExit.transform.position);
    }
}