using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInventory _inventory;
    private CameraStateManager _cameraStateManager;

    public PlayerInventory PlayerInventory { get => _inventory; set => _inventory = value; }
    public CameraStateManager CameraStateManager { get => _cameraStateManager; set => _cameraStateManager = value; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = GetComponent<PlayerInventory>();
        CameraStateManager = GetComponent<CameraStateManager>();
    }
}
