using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Toggleable
{
    [SerializeField] GameObject _offStateObject;
    [SerializeField] GameObject _onStateObject;

    protected override void ToggleOFF()
    {
        
    }

    protected override void ToggleON()
    {
        GetComponent<BoxCollider>().enabled = false;
        _offStateObject.SetActive(false);
        _onStateObject.SetActive(true);
        this.enabled = false;
    }
}
