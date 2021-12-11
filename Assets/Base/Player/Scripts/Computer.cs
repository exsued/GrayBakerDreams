using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject Terminal;
    public Animator anims;
    public static Computer instance { get; private set; }
    public bool actived { get; private set; }

    IEnumerator Start()
    {
        instance = this;
        actived = false;
        anims.enabled = false;
        var player = Player.instance;
        var playerCam = player.alignCamera;
        yield return null;
        while (player == null || playerCam == null)
        {
            player = Player.instance;
            playerCam = player.alignCamera;
            yield return null;
        }
        //yield return new WaitWhile(() => Player.instance && Player.instance.alignCamera);

        
        while (true)
        {
            if (Input.GetButton("Jump") && Player.instance.CanUseComputer)
            {
                playerCam.CursorActived = true;
                actived = true;
                anims.enabled = true;
                anims.Play("showNotebook", -1);
                yield return new WaitForSeconds(0.5f);
                Terminal.SetActive(true);
                yield return new WaitWhile(() => !Input.GetButton("Jump"));
                Terminal.SetActive(false);
                playerCam.CursorActived = false;
                anims.Play("hideNotebook", -1);
                yield return new WaitForSeconds(0.5f);
                actived = false;
            }
            yield return null;
        }    
        
    }
}
