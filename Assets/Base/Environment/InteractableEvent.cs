using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableEvent : MonoBehaviour, Interactable
{
    public UnityEvent events;
    public void Interact()
    {
        events.Invoke();
    }
}
