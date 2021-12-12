using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableEvent : MonoBehaviour, Interactable
{
    public UnityEvent events;
    public AudioClip pickup;
    public void Interact()
    {
        events.Invoke();
        AudioSource src = new GameObject("_interact", typeof(AudioSource)).GetComponent<AudioSource>();
        src.clip = pickup;
        src.Play();
        Destroy(src.gameObject, 5f);
    }
}
