using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    IEnumerator Start()
    {
        var light = GetComponent<Light>();
        while (true)
        {
            if (Input.GetButton("Flashlight"))
            {
                light.enabled = !light.enabled;
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
    }
}
