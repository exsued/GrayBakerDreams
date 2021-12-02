using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Smaller : MonoBehaviour, Interactable
{
    public GameObject level;
    public GameObject[] Lights;
    public float roomMagSpeed, biggertime;
    bool isInteracted = false;
    [SerializeField]
    public UnityEvent events = null;
    public void Interact()
    {
        if (isInteracted)
            return;
        isInteracted = true;
        StartCoroutine(bigger());
        print("it's work");
        foreach(var light in Lights)
        {
            light.SetActive(true);
        }
        events.Invoke();
    }
    IEnumerator bigger()
    {
        var newScale = level.transform.localScale * 12f;
        var time = Time.time + biggertime;
        while(Vector3.Distance(level.transform.localScale, newScale) > 0.1f && time >= Time.time)
        {
            level.transform.localScale = Vector3.Lerp(level.transform.localScale, newScale, Time.deltaTime * roomMagSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}
