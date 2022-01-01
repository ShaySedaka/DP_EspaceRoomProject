using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : ToggleableItemRequired
{
    [SerializeField] GameObject _offStateObject;
    [SerializeField] GameObject _onStateObject;

    [SerializeField] GameObject _roomTransfer;
    protected override void ToggleOFF()
    {
        Debug.Log("Oops");
    }

    protected override void ToggleON()
    {
        //GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;
        _offStateObject.SetActive(false);
        _onStateObject.SetActive(true);
        _roomTransfer.SetActive(true);
    }
}
