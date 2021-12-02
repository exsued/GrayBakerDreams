using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CowmanInit : MonoBehaviour
{
    public AudioSource radioSource;
    public AudioClip cowmanKill;
    public GameObject DoorKnock;
    public GameObject deskPunchSource;
    public AudioSource cowmanWalking;
    public GameObject[] Lights;
    public UnityEvent onstartRadeEvents = null;
    [SerializeField]
    public UnityEvent onendRadeEvents = null;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        onstartRadeEvents.Invoke();
        radioSource.clip = cowmanKill;
        radioSource.Play();
        radioSource.loop = false;
        yield return new WaitForSeconds(10f);
        DoorKnock.SetActive(false);
        deskPunchSource.SetActive(true);
        yield return new WaitForSeconds(5f);
        cowmanWalking.enabled = true;
        yield return new WaitForSeconds(48f);
        foreach (var light in Lights)
        {
            light.SetActive(true);
        }
        onendRadeEvents.Invoke();
    }
}
