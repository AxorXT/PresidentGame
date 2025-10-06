using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManagerA : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject exitDoor;
    public string lobbySceneName = "Lobby";

    private bool sabotageDone = false;

    void Start()
    {
        // Spawn del player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
        }

        // Puerta desactivada
        if (exitDoor != null)
            exitDoor.SetActive(false);

        StartCoroutine(ShowInitialObjectiveNextFrame());
    }

    IEnumerator ShowInitialObjectiveNextFrame()
    {
        yield return null; // espera un frame
        if (PersistentHUD.instance != null)
            PersistentHUD.instance.SetObjectiveText("Sabotea los micrófonos para impedir que transmitan su mensaje");
    }

    public void OnSabotageComplete()
    {
        sabotageDone = true;

        // Actualizar HUD
        PersistentHUD.instance?.SetObjectiveText("Sabotaje completado Regresa a la puerta de salida");
        PersistentHUD.instance?.ShowInteractText("Presiona E");

        if (exitDoor != null)
            exitDoor.SetActive(true);
    }

    public void OnExitDoorInteract()
    {
        if (sabotageDone)
            SceneManager.LoadScene(lobbySceneName);
    }
}
