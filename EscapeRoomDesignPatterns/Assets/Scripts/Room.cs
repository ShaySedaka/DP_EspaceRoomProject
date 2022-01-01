using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private int _roomID;
    [SerializeField] private Transform _defaultCameraAngle;
    [SerializeField] private List<Transform> _cameraAngles;

    public int RoomID { get => _roomID; set => _roomID = value; }
    public Transform DefaultCameraAngle { get => _defaultCameraAngle; set => _defaultCameraAngle = value; }
    public List<Transform> CameraAngles { get => _cameraAngles; set => _cameraAngles = value; }
}
