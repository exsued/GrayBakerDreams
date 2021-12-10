using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour,Interactable
{
    public MeshRenderer mesh;
    Material alarmMaterial;
    public Animator anim;
    public AudioSource sound;
    public AudioClip buttonOff;
    public bool onStartEnabled = true;
    bool isEnabled = true;

    public void Interact()
    {
        isEnabled = !onStartEnabled;
    }

    IEnumerator Start()
    {
        isEnabled = onStartEnabled;
        if (isEnabled)
        {
            yield return new WaitWhile(() => isEnabled);
            alarmMaterial = mesh.materials[0];
            Destroy(anim);
            anim.enabled = false;
            sound.Stop();
            sound.loop = false;
            sound.PlayOneShot(buttonOff);
            alarmMaterial.SetColor("_Color", Color.black);
            alarmMaterial.SetColor("_EmissionColor", Color.black);
        }
        else
        {
            alarmMaterial = mesh.materials[0];
            Destroy(anim);
            sound.Stop();
            sound.loop = false;
            alarmMaterial.SetColor("_Color", Color.black);
            alarmMaterial.SetColor("_EmissionColor", Color.black);
            yield return new WaitWhile(() => !isEnabled);
            sound.loop = false;
            alarmMaterial.SetColor("_Color", Color.white);
            alarmMaterial.SetColor("_EmissionColor", Color.white);
            sound.PlayOneShot(buttonOff);
        }
    }

}
