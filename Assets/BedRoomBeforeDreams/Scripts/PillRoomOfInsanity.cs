using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillRoomOfInsanity : MonoBehaviour, Interactable
{
    public void Interact()
    {
        BedRoom.nextLevel = "RoomOfInsanity";
        Destroy(gameObject);
    }
}
