using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableYellow : Toggleable
{
    [SerializeField] GameObject _sphereChild;
    [SerializeField] GameObject _cubeChild;


    protected override void ToggleOFF()
    {
        _sphereChild.SetActive(false);
        _cubeChild.SetActive(true);
    }

    protected override void ToggleON()
    {
        _sphereChild.SetActive(true);
        _cubeChild.SetActive(false);
    }
}
