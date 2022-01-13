using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInventory _playerInventory;
    private CameraStateManager _cameraStateManager;

    public PlayerInventory PlayerInventory { get => _playerInventory; set => _playerInventory = value; }
    public CameraStateManager CameraStateManager { get => _cameraStateManager; set => _cameraStateManager = value; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = GetComponent<PlayerInventory>();
        CameraStateManager = GetComponent<CameraStateManager>();
    }
}
