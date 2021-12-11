using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    public AudioClip offices;
    public AudioClip streets;
    public AudioClip domofone;

    public string levelName;
    IEnumerator Start()
    {
        StartCoroutine(_audio());
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene(levelName);
    }
    IEnumerator lerpVolume(AudioSource source, float value)
    {
        float speed = 1f;
        float eps = 0.01f;
        while(Mathf.Abs(value - source.volume) > eps)
        {
            source.volume = Mathf.Lerp(source.volume, value, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame(); 
        }
    }
    IEnumerator _audio()
    {
        AudioSource source = new GameObject("snd", typeof(AudioSource)).GetComponent<AudioSource>();
        source.loop = true;
        source.volume = 0.5f;
        source.clip = offices;
        source.Play();
        yield return new WaitForSeconds(10);
        yield return StartCoroutine(lerpVolume(source, 0f));
        source.Stop();
        source.clip = streets;
        source.Play();
        yield return StartCoroutine(lerpVolume(source, 0.5f));
        yield return new WaitForSeconds(8);
        source.PlayOneShot(domofone);
        yield return StartCoroutine(lerpVolume(source, 0f));
    }
}
