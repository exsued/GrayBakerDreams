using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipMessage : MonoBehaviour
{
    public string text;
    public Text textMesh;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            textMesh.text = text;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textMesh.text = "";
        }
    }
}
