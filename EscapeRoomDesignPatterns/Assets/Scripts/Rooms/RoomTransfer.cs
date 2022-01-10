using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : Interactible
{
    /*[SerializeField] */ CameraStateManager _playerStateManager;

    [SerializeField] Room _room1;
    [SerializeField] Room _room2;


    void Start()
    {
        _playerStateManager = GameManager.Instance.Player.CameraStateManager;
    }

    public override void Interact()
    {
        MoveBetweenRooms();
    }

    public void MoveBetweenRooms()
    {
        int currentRoomID = _playerStateManager.CurrentRoom.RoomID;

        if(currentRoomID == _room1.RoomID)
        {
            TransferToRoom(_room2);
        }
        else if(currentRoomID == _room2.RoomID)
        {
            TransferToRoom(_room1);
        }
    }

    private void TransferToRoom(Room room)
    {
        _playerStateManager.CurrentRoom = room;
        _playerStateManager.InitializeCameraState();
    }
}
