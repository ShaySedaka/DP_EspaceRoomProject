using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateManager : MonoBehaviour
{
    [SerializeField] private Room _currentRoom;
    [SerializeField] private CameraState _currentCameraState;
    private List<CameraState> _roomCameraStates = new List<CameraState>();
    private bool _isLerping = false;

    public Room CurrentRoom { get => _currentRoom; set => _currentRoom = value; }

    void Start()
    {
        InitializeCameraState();
    }

    public void LookRight()
    {
        if(!_isLerping)
        {
            StartCoroutine(ChangeCurrentCameraStateToTarget(_currentCameraState.RightSideState));
        }
    }

    public void LookLeft()
    {
        if (!_isLerping)
        {
            StartCoroutine(ChangeCurrentCameraStateToTarget(_currentCameraState.LeftSideState));
        }
    }

    public void InitializeCameraState()
    {
        _roomCameraStates.Clear();

        // creating the base CameraState object and adding them to the room state list
        for (int i = 0; i < CurrentRoom.CameraAngles.Count; i++)
        {
            CameraState cs = new CameraState();
            cs.CameraStateTranform = CurrentRoom.CameraAngles[i];
            _roomCameraStates.Add(cs);
        }

        // connecting the state in the room state list cyclicaly 
        for (int i = 0; i < _roomCameraStates.Count; i++)
        {
            CameraState cs = _roomCameraStates[i];
            cs.LeftSideState = _roomCameraStates[(i-1 >= 0) ? (i-1) : (_roomCameraStates.Count - 1)];
            cs.RightSideState = _roomCameraStates[(i + 1) % (_roomCameraStates.Count)];
        }

        StartCoroutine(ChangeCurrentCameraStateToTarget(_roomCameraStates[0]));
    }

    private IEnumerator ChangeCurrentCameraStateToTarget(CameraState targetCameraState, float transitionTime = 1.5f)
    {
        float elapsedTime = 0;

        // Transition between Camera States will always take 1 second
        float waitTime = transitionTime;

        Vector3 targetPosition = targetCameraState.CameraStateTranform.position;
        Quaternion targetRotation = targetCameraState.CameraStateTranform.rotation;

        _isLerping = true;
        while (elapsedTime <= waitTime)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / waitTime);
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        _isLerping = false;

        gameObject.transform.position = targetPosition;
        gameObject.transform.rotation = targetRotation;
        _currentCameraState = targetCameraState;
        yield return null;

    }

}
