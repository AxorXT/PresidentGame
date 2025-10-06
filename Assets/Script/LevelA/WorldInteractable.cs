using UnityEngine;
using UnityEngine.InputSystem;

public class WorldInteractable : MonoBehaviour
{
    public InputActionReference interactAction;
    public string interactTextMessage = "Presiona E";
    public float interactDistance = 3f;

    // Ahora puede referenciar cualquier LevelManager, no solo el de tipo A
    public MonoBehaviour levelManager;

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null || PersistentHUD.instance == null) return;

        Vector3 playerPos = player.transform.position;
        Vector3 direction = transform.position - playerPos;

        if (direction.magnitude <= interactDistance)
        {
            Vector3 forward = player.transform.forward;
            if (Vector3.Dot(direction.normalized, forward) > 0.8f)
            {
                PersistentHUD.instance.ShowInteractText(interactTextMessage);

                if (interactAction.action.WasPressedThisFrame())
                {
                    Interact();
                }
                return;
            }
        }

        PersistentHUD.instance.HideInteractText();
    }

    public virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
