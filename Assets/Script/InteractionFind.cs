using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionFind : MonoBehaviour
{
    private Interactable inter = null;
    public GameObject interIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interIcon.SetActive(false);
    }
    public void OnInteract(InputAction.CallbackContext context) {
        if (context.performed) { 
        inter?.Interact();
        }
    
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable.CanInteract())
        {
            inter = interactable;
            interIcon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable == inter)
        {
            inter = null;
            interIcon.SetActive(false);
        }
    }
}
