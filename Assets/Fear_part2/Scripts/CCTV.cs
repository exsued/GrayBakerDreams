using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    public RenderTexture camTexture;
    public Material camMaterial;
    public GameObject[] cameras;
    float curCamInd = 0f;

    private void Start()
    {
        RefreshCamView();
    }
    public void OnNext()
    {
        curCamInd = Mathf.Repeat(curCamInd + 1, cameras.Length);
        RefreshCamView();
    }
    public void OnPrev()
    {
        curCamInd = Mathf.Repeat(curCamInd - 1, cameras.Length);
        RefreshCamView();
    }
    void RefreshCamView()
    {
        foreach(var cam in cameras)
        {
            cam.SetActive(false);
        }
        cameras[(int)curCamInd].SetActive(true);
        cameras[(int)curCamInd].GetComponent<Camera>().targetTexture = camTexture;
    }
}
