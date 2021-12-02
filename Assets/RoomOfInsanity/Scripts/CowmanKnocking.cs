using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CowmanKnocking : MonoBehaviour
{
    public AudioClip cowmanKill;
    public GameObject doorPunch;
    public Image blackScreen;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(60f);
        Player.instance.gameObject.GetComponent<Collider>().tag = "Untagged";
        blackScreen.color = Color.black;
        doorPunch.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gameObject.AddComponent<AudioSource>().clip = cowmanKill;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
