using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowInsane : MonoBehaviour
{
    public Material background;
    public Texture2D eyesImage;

    private void Start()
    {
        background.color = Color.black;
    }
    public void MakeInsane()
    {
        background.mainTexture = eyesImage;
        background.color = Color.white;
    }
    public void MakeSane()
    {
        background.color = Color.black;
    }
}
