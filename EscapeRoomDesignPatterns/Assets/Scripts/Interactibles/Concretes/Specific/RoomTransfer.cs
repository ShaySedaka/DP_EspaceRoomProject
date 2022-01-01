using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    [SerializeField] CameraStateManager _playerStateManager;

    [SerializeField] Room _room1;
    [SerializeField] Room _room2;

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
