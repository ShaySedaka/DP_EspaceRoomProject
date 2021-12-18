using System;
using System.Collections;
using UnityEngine;

public class CameraState
{
    Transform _currentCameraTranform;
    CameraState _rightSideState, _leftSideState;

    public Transform CurrentCameraTranform { get => _currentCameraTranform; set => _currentCameraTranform = value; }
    public CameraState RightSideState { get => _rightSideState; set => _rightSideState = value; }
    public CameraState LeftSideState { get => _leftSideState; set => _leftSideState = value; }

}