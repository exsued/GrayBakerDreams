using UnityEngine;
using UnityEngine.Events;

public class Keycard : MonoBehaviour, Interactable
{
    public UnityEvent pickupEffect;

    public void Interact()
    {
        pickupEffect.Invoke();
        Destroy(gameObject);
    }
}
