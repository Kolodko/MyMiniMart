using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AnimatorController _animatorController;
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] ParticleSystem _particle;

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;

    private Rigidbody _rigidbody;
    private Vector3 _moveVector;

    private bool test;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Передвижение игрока
    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.z -= _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.x = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            if (test == false)
            {
                test = true;
                _particle.Play();
            }

            _animatorController.PlayRun();
        }

        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            if (test)
            {
                test = false;
                _particle.Stop();
            }
            _animatorController.PlayIdle();
        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }
}