using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : PlayerStats
{
    [SerializeField]
    private CharacterController _controller;
    private int _lane = 0;       
    private Vector3 _moveVector = Vector3.zero;
    private bool _hitStrafeButton = false;

    private void Update()
    {    
        MoveForward();
        MoveToSides();               
    }

    private void MoveForward()
    {              
        _moveVector.z = Speed;
        _controller.Move(_moveVector * Time.deltaTime);
    }

    private void MoveToSides()
    {                
            if (Input.GetAxisRaw("Horizontal") < 0 && _lane > -2)
            {
                if (!_hitStrafeButton)
                {
                    _lane-=2;
                    _hitStrafeButton = true;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && _lane < 2)
            {
                if (!_hitStrafeButton)
                {
                    _lane+=2;
                    _hitStrafeButton = true;
                }
            }
            else
            _hitStrafeButton = false;
        Vector3 newPosition = transform.position;
        newPosition.x = _lane;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * Speed);
    }

    public float PositionZ()
    {
        return transform.position.z;
    }

    public Collider ReturnCollider()
    {
        return GetComponent<CapsuleCollider>(); 
    }
}
