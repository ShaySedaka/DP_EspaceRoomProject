using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Toggleable : Interactible
{
    public enum ToggleState
    {
        ON,
        OFF
    }

    public ToggleState CurrentToggleState;
    protected abstract void ToggleON();
    protected abstract void ToggleOFF();

    public override void Interact()
    {
        if(CurrentToggleState == ToggleState.ON)
        {
            ToggleOFF();
            CurrentToggleState = ToggleState.OFF;
        }
        else
        {
            ToggleON();
            CurrentToggleState = ToggleState.ON;
        }
    }

}
