using UnityEngine;
using UnityEngine.Events;

public class CCTVServer : MonoBehaviour
{
    public UnityEvent onClickServer;
    void OnMouseDown()
    {
        onClickServer?.Invoke();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            onClickServer?.Invoke();
        }
    }
}
