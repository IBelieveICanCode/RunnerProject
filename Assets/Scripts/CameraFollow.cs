using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform LookAt;
    private Vector3 
        _offset, 
        _cameraMove;
    private float
        _transition = 0f,
        _animationDuration = 1.5f;
    private void Start()
    {
        _offset = transform.position - LookAt.position;
    }
    // Update is called once per frame
    void Update()
    {
        //CheckIfGameStarts();
        CameraInGamePosition();        
    }

    private void CameraInGamePosition()
    {
        _cameraMove = LookAt.position + _offset;
        _cameraMove.x = 0;
        _cameraMove.y = Mathf.Clamp(_cameraMove.y, 3, 5);
        transform.position = _cameraMove;
    }

    private void CheckIfGameStarts()
    {
        if (_transition > 1f)
            transform.position = _cameraMove;
        else
            StartCameraAnimation();
    }

    private void StartCameraAnimation()
    {
        transform.position = Vector3.Lerp(_cameraMove + new Vector3(0, 5, 5), _cameraMove, _transition);
        _transition += Time.deltaTime * 1 / _animationDuration;
    }

  
}
