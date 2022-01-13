using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardDoors : ToggleableItemRequired
{
    [SerializeField] private GameObject _rightDoorCylinder;
    [SerializeField] private GameObject _leftDoorCylinder;

    private float _turnAngle = 121;
    protected override void ToggleOFF()
    {
        _rightDoorCylinder.transform.Rotate(new Vector3(0, _turnAngle, 0));
        _leftDoorCylinder.transform.Rotate(new Vector3(0, -_turnAngle, 0));
    }

    protected override void ToggleON()
    {
        _rightDoorCylinder.transform.Rotate(new Vector3(0, -_turnAngle, 0));
        _leftDoorCylinder.transform.Rotate(new Vector3(0, _turnAngle, 0));
    }
}
