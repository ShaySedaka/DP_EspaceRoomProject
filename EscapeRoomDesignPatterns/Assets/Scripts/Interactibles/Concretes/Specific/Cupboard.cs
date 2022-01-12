using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : ToggleableItemRequired
{
    [SerializeField] private GameObject _rightDoorCylinder;
    [SerializeField] private GameObject _leftDoorCylinder;
    protected override void ToggleOFF()
    {
        _rightDoorCylinder.transform.Rotate(new Vector3(0, 121, 0));
        _leftDoorCylinder.transform.Rotate(new Vector3(0, -121, 0));
    }

    protected override void ToggleON()
    {
        _rightDoorCylinder.transform.Rotate(new Vector3(0, -121, 0));
        _leftDoorCylinder.transform.Rotate(new Vector3(0, 121, 0));
    }
}
