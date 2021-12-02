using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeQuest : MonoBehaviour
{
    public bool A { get; set; }
    public bool L { get; set; }
    public bool O { get; set; }
    public bool N { get; set; }
    public bool E { get; set; }
    public Button[] buttons;
    public GameObject openButton;
    void Update()
    {
        if (A && L && O && N && E)
            openButton.SetActive(true);
    }

    public void OnFailedCode()
    {
        A = L = O = N = E = false;
        foreach (var button in buttons)
            button.interactable = true;
    }
}
