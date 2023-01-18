using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerUi;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    private Transform _camera;
    private Vector3 _offset, _offsetUi;


    private void Awake()
    {
        _camera = this.transform;
        _offset = _camera.position - _player.position;

        _offsetUi = _playerUi.position - _player.position;
    }

    private void Update()
    {
        Follow();
    }

    //Перемещение за игроком камеры и Ui
    private void Follow()
    {
        _camera.DOMoveX(_player.position.x + _offset.x, _speed * Time.deltaTime);
        _camera.DOMoveZ(_player.position.z + _offset.z, _speed * Time.deltaTime);

        _playerUi.DOMoveX(_player.position.x + _offsetUi.x, _speed * Time.deltaTime);
        _playerUi.DOMoveZ(_player.position.z + 0.15f + _offsetUi.z, _speed * Time.deltaTime);

    }
}