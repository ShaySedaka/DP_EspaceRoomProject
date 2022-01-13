using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Transform _defaultCameraAngle;
    private List<Transform> _cameraAngles = new List<Transform>();
    
    [SerializeField] private int _roomID;
    [SerializeField] private GameObject _roomCameraAnglesGO;

    public Transform DefaultCameraAngle { get => _defaultCameraAngle; set => _defaultCameraAngle = value; }
    public List<Transform> CameraAngles { get => _cameraAngles; set => _cameraAngles = value; }
    public int RoomID { get => _roomID; set => _roomID = value; }

    private void Awake()
    {
        InitializeCameraAngles();
        InitializeLookDownAngle();
        DefaultCameraAngle = CameraAngles[0];
    }

    private void InitializeLookDownAngle()
    {
        foreach (var transform in _cameraAngles)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x + 5.675f,
                transform.eulerAngles.y,
                transform.eulerAngles.z
            );
        }
    }

    private void InitializeCameraAngles()
    {
        Transform[] cameraAnglesTransforms = _roomCameraAnglesGO.GetComponentsInChildren<Transform>();
        foreach (Transform childTransform in cameraAnglesTransforms)
        {
            _cameraAngles.Add(childTransform);
        }

        /** 
           GetComponentsInChildren<T>() returns the T component of the parent as well, if it exists.
           Since we dont want that, we remove the parent (first cell) in the List
        **/
        _cameraAngles.Remove(_cameraAngles[0]);
    }
}
