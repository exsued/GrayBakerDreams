using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSound : MonoBehaviour, Interactable
{
    private AudioSource source;
    public float intervalTime = 1f;
    bool interactable;
    public void Interact()
    {
        if (interactable)
            return;
        source.Play();
        interactable = true;
        StartCoroutine(timeOut());
    }
    IEnumerator timeOut()
    {
        yield return new WaitForSeconds(intervalTime);
        interactable = false;
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
}
