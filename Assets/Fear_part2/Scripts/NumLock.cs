using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumLock : MonoBehaviour
{
    public Text text;
    public Button catchButton;
    public int correctNumb;
    int curNum;
    public float freshInterval;

    public bool catched {get; private set;}
    private void OnEnable()
    {
        catchButton.interactable = true;
        StartCoroutine(OnEnabled());
    }
    IEnumerator OnEnabled()
    {
        curNum = Random.Range(0, 10);
        while (!catched)
        {
            yield return new WaitForSeconds(freshInterval);
            curNum = (int)Mathf.Repeat(curNum + 1, 10);
            text.text = curNum.ToString();
            if (curNum == correctNumb)
                text.color = Color.green;
            else
                text.color = Color.white;
        }
    }

    public void OnStopButtonClick()
    {
        if (curNum == correctNumb)
        {
            StopAllCoroutines();
            catchButton.interactable = false;
            catched = true;
        }
    }
}
