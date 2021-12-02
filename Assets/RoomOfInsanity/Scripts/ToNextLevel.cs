using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour, Interactable
{
    public void Interact()
    {
        SceneManager.LoadScene(1);
    }
}
