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
        StartCoroutine(ChangeCurrentCameraStateToTarget(_currentCameraState.RightSideState));

    }

    public void LookLeft()
    {
        StartCoroutine(ChangeCurrentCameraStateToTarget(_currentCameraState.LeftSideState, 0.5f));
    }

    public void InitializeCameraState()
    {
        // creating the base CameraState object and adding them to the room state list
        for (int i = 0; i < CurrentRoom.CameraAngles.Count; i++)
        {
            CameraState cs = new CameraState();
            cs.CameraStateTranform = CurrentRoom.CameraAngles[i];
            _RoomCameraStates.Add(cs);
        }

        // connecting the state in the room state list cyclicaly 
        for (int i = 0; i < _RoomCameraStates.Count; i++)
        {
            CameraState cs = _RoomCameraStates[i];
            cs.LeftSideState = _RoomCameraStates[(i-1 >= 0) ? (i-1) : (_RoomCameraStates.Count - 1)];
            cs.RightSideState = _RoomCameraStates[(i + 1) % (_RoomCameraStates.Count)];
        }

        StartCoroutine(ChangeCurrentCameraStateToTarget(_RoomCameraStates[0]));
    }

    private IEnumerator ChangeCurrentCameraStateToTarget(CameraState targetCameraState, float transitionTime = 1f)
    {
        float elapsedTime = 0;

        // Transition between Camera States will always take 1 second
        float waitTime = transitionTime;

        Vector3 targetPosition = targetCameraState.CameraStateTranform.position;
        Quaternion targetRotation = targetCameraState.CameraStateTranform.rotation;

        while (elapsedTime < waitTime)
        {
            playerGO.transform.position = Vector3.MoveTowards(transform.position, targetPosition, elapsedTime/waitTime);
            playerGO.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        playerGO.transform.position = targetPosition;
        playerGO.transform.rotation = targetRotation;
        _currentCameraState = targetCameraState;
        yield return null;

    }

}
