using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TVSystem : MonoBehaviour
{
    int EnabledTVsCount = 4;
    public UnityEvent startAlarmEvent;
    public Image playerScreenPanel;
    public string nextScene;
    public void OnTVOff()
    {
        EnabledTVsCount--;
        if (EnabledTVsCount == 0)
        {
            StartCoroutine(firstLevelEnding());
        }
    }
    IEnumerator firstLevelEnding()
    {
        yield return new WaitForSeconds(4f);
        startAlarmEvent.Invoke();
        StartCoroutine(shaking());
        playerScreenPanel.color = new Color(1f, 0f, 0f, 0.4f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextScene);
    }
    IEnumerator shaking()
    {
        while(true)
        {
            Player.instance.alignCamera.Shake(1f, 1f);
            yield return new WaitForEndOfFrame();
        }
    }
}
