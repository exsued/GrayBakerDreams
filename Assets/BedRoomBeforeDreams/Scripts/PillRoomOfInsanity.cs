using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillRoomOfInsanity : MonoBehaviour, Interactable
{
    public AudioClip swallow;
    public void Interact()
    {
        BedRoom.nextLevel = "RoomOfInsanity";
        AudioSource gameObj = new GameObject("swallow_sound", typeof(AudioSource)).GetComponent<AudioSource>();
        gameObj.PlayOneShot(swallow);
        Destroy(gameObj.gameObject, 2f);
        Destroy(gameObject);
    }
}
