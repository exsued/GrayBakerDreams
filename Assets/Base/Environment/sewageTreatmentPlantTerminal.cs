using UnityEngine;
using System.Collections;

public class sewageTreatmentPlantTerminal : MonoBehaviour, Interactable
{
    public Canvas monitor;
    public Transform workPoint; //В какой позиции игрок работает
    public Transform playerLookPoint;
    public float camAngle;
    public Transform camPos;
    public GameObject loadingWindow;
    //private FMOD.Studio.EventInstance audioSource;
    bool activated = false;
    Vector3 startPos;
    void Start()
    {
        monitor.gameObject.SetActive(false);
    }
    void PlayAudio(string soundPath)
    {
        StartCoroutine(LoadingWindow(3f));
        //audioSource = FMODUnity.RuntimeManager.CreateInstance(soundPath);
        //audioSource.start();
        //audioSource.release();
    }
    public void Interact()
    {
        if (Computer.instance && Computer.instance.actived)
            return;
        StartCoroutine(PlayerWorkWithTerminal());
    }
    IEnumerator LoadingWindow(float time)
    {
        loadingWindow.SetActive(true);
        yield return new WaitForSeconds(time);
        loadingWindow.SetActive(false);
    }
    public void OnDestroy()
    {
        if (!activated)
            return;
        var player = Player.instance;
        var playerCam = player.alignCamera;
        playerCam.CursorActived = false;
        playerCam.actived = true;
        monitor.gameObject.SetActive(false);
        Player.instance.enabled = true;
        playerCam.transform.localPosition = Vector3.zero;
        if(Computer.instance != null)
            Computer.instance.enabled = true;
        playerCam.StopLookAt();
        playerCam.XLockRotate = playerCam.YLockRotate = false;
        activated = false;
    }
    IEnumerator PlayerWorkWithTerminal()
    {
        activated = true;
        Player.instance.CanUseComputer = false;
        var player = Player.instance;
        var playerCam = player.alignCamera;

        Player.instance.enabled = false;

        playerCam.XLockRotate = playerCam.YLockRotate = true;
        playerCam.StartLookAt(workPoint.rotation, camAngle);
        startPos = playerCam.transform.position;
        yield return StartCoroutine(playerCam.TranslateAtPosition(workPoint));
        monitor.gameObject.SetActive(true);
        yield return StartCoroutine(LoadingWindow(0.5f));
        playerCam.CursorActived = true;
        while (Input.GetKey(KeyCode.F))
        {
            yield return null;
        }
        while (!Input.GetKey(KeyCode.F))
        {
            yield return null;
        }
        yield return StartCoroutine(playerCam.TranslateAtPosition(startPos));
        playerCam.CursorActived = false;
        playerCam.actived = true;
        monitor.gameObject.SetActive(false);
        Player.instance.enabled = true;
        playerCam.StopLookAt();
        playerCam.XLockRotate = playerCam.YLockRotate = false;
        Player.instance.CanUseComputer = true;
        activated = false;
    }
}
