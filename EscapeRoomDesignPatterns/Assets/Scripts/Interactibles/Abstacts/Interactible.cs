using UnityEngine;


public abstract class Interactible : MonoBehaviour
{
    public abstract void Interact();

    private void OnMouseDown()
    {
        Interact();
    }
}

