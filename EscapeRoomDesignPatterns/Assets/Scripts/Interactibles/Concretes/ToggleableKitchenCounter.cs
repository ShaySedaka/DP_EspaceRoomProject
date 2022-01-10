using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableKitchenCounter : Toggleable
{
    [SerializeField] GameObject _closedGameObject;
    [SerializeField] GameObject _openGameObject;


    protected override void ToggleOFF()
    {
        _closedGameObject.SetActive(true);
        _openGameObject.SetActive(false);
    }

    protected override void ToggleON()
    {
        _closedGameObject.SetActive(false);
        _openGameObject.SetActive(true);
    }
}