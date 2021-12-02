using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TV : MonoBehaviour, Interactable
{
    public Material screen;
    bool interactable = false;
    public UnityEvent events;
    void Start()
    {
        screen.SetColor("_EmissionColor", Color.white);
    }
    public void Interact()
    {
        if (interactable)
            return;
        interactable = true;
        events.Invoke();
        screen.SetColor("_Color", Color.black);
        screen.SetColor("_EmissionColor", Color.black);
        GetComponent<AudioSource>().enabled = true;
    }
}
