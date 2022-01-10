using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private int _roomID;
    private Transform _defaultCameraAngle;
    [SerializeField] private List<Transform> _cameraAngles;

    private void Start()
    {
        InitializeLookDownAngle();
        DefaultCameraAngle = CameraAngles[0];
    }

    public int RoomID { get => _roomID; set => _roomID = value; }
    public Transform DefaultCameraAngle { get => _defaultCameraAngle; set => _defaultCameraAngle = value; }
    public List<Transform> CameraAngles { get => _cameraAngles; set => _cameraAngles = value; }

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
}
