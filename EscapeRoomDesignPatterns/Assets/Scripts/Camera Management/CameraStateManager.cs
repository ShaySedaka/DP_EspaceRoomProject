using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateManager : MonoBehaviour
{
    [SerializeField] List<Transform> _cameraAngles;
    [SerializeField] CameraState _currentCameraState;
    [SerializeField] Camera _playerCamera;

    private List<CameraState> _RoomCameraStates = new List<CameraState>();

    void Start()
    {
        InitializeCameraState();
        _currentCameraState = _RoomCameraStates[0];
        MoveCameraToCurrentTranform();
    }


    public void LookRight()
    {
        _currentCameraState = _currentCameraState.RightSideState;
        MoveCameraToCurrentTranform();

    }

    public void LookLeft()
    {
        _currentCameraState = _currentCameraState.LeftSideState;
        MoveCameraToCurrentTranform();
    }

    private void InitializeCameraState()
    {
        // creating the base CameraState object and adding them to the room state list
        for (int i = 0; i < _cameraAngles.Count; i++)
        {
            CameraState cs = new CameraState();
            cs.CurrentCameraTranform = _cameraAngles[i];
            _RoomCameraStates.Add(cs);
        }

        // connecting the state in the room state list cyclicaly 
        for (int i = 0; i < _RoomCameraStates.Count; i++)
        {
            CameraState cs = _RoomCameraStates[i];
            cs.LeftSideState = _RoomCameraStates[(i-1 >= 0) ? (i-1) : (_RoomCameraStates.Count - 1)];
            cs.RightSideState = _RoomCameraStates[(i + 1) % (_RoomCameraStates.Count)];
        }
    }

    private void MoveCameraToCurrentTranform()
    {
        //turning the camera
        _playerCamera.transform.position = _currentCameraState.CurrentCameraTranform.position;
        _playerCamera.transform.rotation = _currentCameraState.CurrentCameraTranform.rotation;
    }

}
