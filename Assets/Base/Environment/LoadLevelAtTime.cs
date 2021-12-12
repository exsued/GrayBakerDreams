using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAtTime : MonoBehaviour
{
    public float secs = 1.5f;
    public string sceneName;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(sceneName);
    }
}
