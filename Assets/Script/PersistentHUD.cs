using TMPro;
using UnityEngine;

public class PersistentHUD : MonoBehaviour
{
    public static PersistentHUD instance;

    public TMP_Text interactText;
    public TMP_Text objectiveText;
    public UnityEngine.UI.Image crosshair;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    // Funciones para actualizar textos desde cualquier escena
    public void ShowInteractText(string text)
    {
        if (interactText != null)
        {
            interactText.text = text;
            interactText.gameObject.SetActive(true);
        }
    }

    public void HideInteractText()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    public void SetObjectiveText(string text)
    {
        if (objectiveText != null)
            objectiveText.text = text;
    }
}
