using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    public AudioClip offices;
    public AudioClip streets;
    public AudioClip domofone;
    public Text titleText;

    public string levelName;
    IEnumerator Start()
    {
        StartCoroutine(_audio());
        StartCoroutine(_text());
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene(levelName);
    }
    IEnumerator _text()
    {
        yield return new WaitForSeconds(3f);
        titleText.text = "Привет, друг!";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Меня зовут Адип";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Меня стала часто посещать путаница мыслей";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Чувство одиночества, а также сильный страх смерти";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Они разрывают меня изнутри... Это невыносимо\nВрачи не смогли мне помочь с этим";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Однажды один знакомый дал мне пилюлю, по словам которого она могла решить все мои проблемы с головой";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Но также она меня может окончательно свести с ума";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Настал день X. Я прихожу с работы и эта пилюля уже поджидала меня на столе";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "Остается лишь решиться ее выпить и уснуть";
        yield return new WaitForSeconds(2.5f);
        titleText.text = "...";
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
