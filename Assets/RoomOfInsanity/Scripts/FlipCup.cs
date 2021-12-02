using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCup : MonoBehaviour, Interactable
{
    public Animator anim;
    public GameObject col1;
    public GameObject col2;
    void Start()
    {
        anim.enabled = false;
    }
    public void Interact()
    {
        print("It's work");
        anim.enabled = true;
        anim.Play("FlipCup", -1);
        GetComponent<Collider>().enabled = false;
        col1.SetActive(false);
        col2.SetActive(true);
    }
}
