using System;
using System.Collections;
using UnityEngine;

public class CameraState
{
    Transform _cameraStateTransform;
    CameraState _rightSideState, _leftSideState;

    public Transform CameraStateTranform { get => _cameraStateTransform; set => _cameraStateTransform = value; }
    public CameraState RightSideState { get => _rightSideState; set => _rightSideState = value; }
    public CameraState LeftSideState { get => _leftSideState; set => _leftSideState = value; }

}