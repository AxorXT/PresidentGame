using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public class UIRayInteractor : MonoBehaviour
{
    public Camera playerCamera;
    public float rayDistance = 5f;
    public Image crosshair;
    public InputActionReference interactAction;
    public GameObject interactText;

    void Start()
    {
        if (interactText != null)
            interactText.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = playerCamera.WorldToScreenPoint(ray.GetPoint(rayDistance))
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        bool foundButton = false;

        foreach (RaycastResult result in results)
        {
            Button button = result.gameObject.GetComponent<Button>();
            if (button)
            {
                crosshair.color = Color.green;
                foundButton = true;

                if (interactText != null)
                    interactText.SetActive(true);

                if (interactAction.action.WasPressedThisFrame())
                {
                    button.onClick.Invoke();
                }
                break;
            }
        }

        if (!foundButton)
        {
            crosshair.color = Color.white;
            if (interactText != null)
                interactText.SetActive(false);
        }
    }
}