using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour, Interactable
{
    public Alarm alignedAlarm;
    public float AsleepTime;
    public GameObject asleepPlayer;
    public void Interact()
    {
        if (string.IsNullOrEmpty(BedRoom.nextLevel) && alignedAlarm.enabled != alignedAlarm.onStartEnabled)
            return;
        Player.instance.gameObject.SetActive(false);
        asleepPlayer.SetActive(true);
        StartCoroutine(LoadLevelAtTime(5));
    }
    IEnumerator LoadLevelAtTime(float seconds)
    {
        yield return new WaitForSeconds(AsleepTime);
        SceneManager.LoadScene(BedRoom.nextLevel);
    }
}
