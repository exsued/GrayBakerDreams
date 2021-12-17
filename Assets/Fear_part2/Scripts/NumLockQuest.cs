using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

public class NumLockQuest : MonoBehaviour
{
    public NumLock[] locks;
    public UnityEvent onQuestComplete;
    IEnumerator Start()
    {
        yield return new WaitUntil(() => locks.All(x => x.catched));
        onQuestComplete?.Invoke();
    }
}
