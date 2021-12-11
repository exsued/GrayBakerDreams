using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    public UnityEvent events = null;
    public UnityEvent onExitEvents = null;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            events.Invoke();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onExitEvents.Invoke();
        }
    }
    private void OnDestroy()
    {
        onExitEvents.Invoke();
    }
}
