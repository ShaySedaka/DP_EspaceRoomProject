using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopPassword : ToggleableItemRequired
{
    [SerializeField] private GameObject _winCanvas;

    protected override void ToggleOFF()
    {
        
    }

    protected override void ToggleON()
    {
        _winCanvas.SetActive(true);
    }
}
