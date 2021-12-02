using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePickup : MonoBehaviour, Interactable
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    public void Interact()
    {
        anim.enabled = true;
        anim.Play("Show", -1);
    }
}
