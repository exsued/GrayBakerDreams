using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    public UnityEvent events = null;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            events.Invoke();
        }
    }
}
