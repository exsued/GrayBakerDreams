using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAccelerator : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            Time.timeScale = 10f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
