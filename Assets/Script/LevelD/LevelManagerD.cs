using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerD : MonoBehaviour
{
    public Transform spawnPoint;
    public string lobbySceneName = "Lobby";

    [HideInInspector] public int DrinksCollected = 0;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
        }

        PersistentHUD.instance?.SetObjectiveText("Recoge las 2 bebidas");
    }

    public void OnDrinkCollected()
    {
        DrinksCollected++;
        PersistentHUD.instance?.SetObjectiveText($"Bebidas recogidas: {DrinksCollected}/2");

        if (DrinksCollected >= 2)
        {
            PersistentHUD.instance?.SetObjectiveText("Ahora roba la hielera");
        }
    }

    public void OnCoolerStolen()
    {
        PersistentHUD.instance?.SetObjectiveText("Hielera robada — regresa al lobby");
        Invoke(nameof(ReturnToLobby), 2f);
    }

    void ReturnToLobby()
    {
        // Suscribirse antes de cargar la escena
        SceneManager.sceneLoaded += OnLobbyLoaded;

        SceneManager.LoadScene(lobbySceneName);
    }

    private void OnLobbyLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == lobbySceneName)
        {
            // Nos aseguramos de desuscribir inmediatamente para que no se llame otra vez
            SceneManager.sceneLoaded -= OnLobbyLoaded;

            // Espera 1 frame para que LevelManager se inicialice
            StartCoroutine(ActivateHallwayNextFrame());
        }
    }

    private IEnumerator ActivateHallwayNextFrame()
    {
        yield return null; // espera 1 frame

        LevelManager lobbyManager = FindAnyObjectByType<LevelManager>();

        if (lobbyManager != null)
        {
            // Asegúrate que hallway y finalNPC estén asignados en el inspector
            lobbyManager.ActivateFinalHallway();
        }
        else
        {
            Debug.LogWarning("No se encontró el LevelManager en el lobby");
        }
    }
}