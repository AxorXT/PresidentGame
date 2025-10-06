using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button btnA, btnB, btnC, btnD;
    private int currentUnlocked = 0; // 0 = A, 1 = B, etc.

    public GameObject hallway;             // Pasillo que se activará
    public GameObject finalNPC;

    public static bool finalHallwayUnlocked = false;

    void Start()
    {
        UpdateButtons();
        btnA.onClick.AddListener(() => LoadLevel("LevelA"));
        btnB.onClick.AddListener(() => LoadLevel("LevelB"));
        btnC.onClick.AddListener(() => LoadLevel("LevelC"));
        btnD.onClick.AddListener(() => LoadLevel("LevelD"));

        if (finalHallwayUnlocked)
            ActivateFinalHallway();
    }

    void UpdateButtons()
    {
        btnA.interactable = (currentUnlocked >= 0);
        btnB.interactable = (currentUnlocked >= 1);
        btnC.interactable = (currentUnlocked >= 2);
        btnD.interactable = (currentUnlocked >= 3);
    }

    public void UnlockNextLevel()
    {
        if (currentUnlocked < 3)
        {
            currentUnlocked++;
            UpdateButtons();
        }
    }

    void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ActivateFinalHallway()
    {
        if (hallway != null) hallway.SetActive(true);
        if (finalNPC != null) finalNPC.SetActive(true);

        // Opcional: mostrar mensaje en HUD
        PersistentHUD.instance?.SetObjectiveText("Sigue el pasillo hacia la persona final");

        finalHallwayUnlocked = true;
    }

    public void EndGame()
    {
        Debug.Log("Juego terminado");
        PersistentHUD.instance?.ShowInteractText(""); // Oculta texto
                                                      // Aquí podrías mostrar menú final o detener movimiento del player
    }
}
