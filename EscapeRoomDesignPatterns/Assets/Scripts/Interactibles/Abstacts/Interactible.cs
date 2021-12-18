﻿using UnityEngine;


public abstract class Interactible : MonoBehaviour
{
    public abstract void Interact();

    void OnMouseDown()
    {
        Interact();
    }
}

