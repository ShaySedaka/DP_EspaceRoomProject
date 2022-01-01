using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateManager : MonoBehaviour
{
    [SerializeField]  private Room _currentRoom;
    [SerializeField] CameraState _currentCameraState;
    [SerializeField] Camera _playerCamera;
    [SerializeField] float _cameraLerpSpeed = 0.5f;
    private GameObject playerGO;

    private List<CameraState> _RoomCameraStates = new List<CameraState>();

    public Room CurrentRoom { get => _currentRoom; set => _currentRoom = value; }

    void Start()
    {
        playerGO = _playerCamera.transform.parent.gameObject;
        InitializeCameraState();
    }

    public void LookRight()
    {
        _currentCameraState = _currentCameraState.RightSideState;
        StartCoroutine(MoveCameraToCurrentTranform());

    }

    public void LookLeft()
    {
        _currentCameraState = _currentCameraState.LeftSideState;
        StartCoroutine(MoveCameraToCurrentTranform());
    }

    public void InitializeCameraState()
    {
        // creating the base CameraState object and adding them to the room state list
        for (int i = 0; i < CurrentRoom.CameraAngles.Count; i++)
        {
            CameraState cs = new CameraState();
            cs.CurrentCameraTranform = CurrentRoom.CameraAngles[i];
            _RoomCameraStates.Add(cs);
        }

        // connecting the state in the room state list cyclicaly 
        for (int i = 0; i < _RoomCameraStates.Count; i++)
        {
            CameraState cs = _RoomCameraStates[i];
            cs.LeftSideState = _RoomCameraStates[(i-1 >= 0) ? (i-1) : (_RoomCameraStates.Count - 1)];
            cs.RightSideState = _RoomCameraStates[(i + 1) % (_RoomCameraStates.Count)];
        }

        _currentCameraState = _RoomCameraStates[0];
        StartCoroutine(MoveCameraToCurrentTranform());
    }

    private IEnumerator MoveCameraToCurrentTranform()
    {


        //turning the camera
        //_playerCamera.transform.position = _currentCameraState.CurrentCameraTranform.position;
        //_playerCamera.transform.rotation = _currentCameraState.CurrentCameraTranform.rotation;

        float elapsedTime = 0;
        float waitTime = 1f;

        Vector3 targetPosition = _currentCameraState.CurrentCameraTranform.position;
        Quaternion targetRotation = _currentCameraState.CurrentCameraTranform.rotation;

        while (elapsedTime < waitTime)
        {
            playerGO.transform.position = Vector3.Slerp(transform.position, targetPosition, elapsedTime/waitTime);
            playerGO.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        playerGO.transform.position = targetPosition;
        playerGO.transform.rotation = targetRotation;
        yield return null;

    }

}
