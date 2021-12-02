using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterKill : MonoBehaviour
{
    public GameObject mainFoosteps;
    public GameObject runFoosteps;
    public Image blackScreen;
    public AudioClip cowmanKill;
    IEnumerator Start()
    {
        mainFoosteps.SetActive(false);
        runFoosteps.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        runFoosteps.SetActive(false);
        blackScreen.color = Color.black;
        gameObject.AddComponent<AudioSource>().clip = cowmanKill;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
