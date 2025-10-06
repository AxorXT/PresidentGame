using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerC : MonoBehaviour
{
    public static LevelManagerC instance;

    public Transform spawnPoint;
    public string lobbySceneName = "Lobby";

    [HideInInspector] public bool BatteryCollected = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
        }

        PersistentHUD.instance?.SetObjectiveText("Encuentra la batería dentro de la casa");
    }

    public void OnBatteryPickedUp()
    {
        BatteryCollected = true;
        PersistentHUD.instance?.SetObjectiveText("Ahora lleva la batería a la piscina");
    }

    public void OnBatteryPlaced()
    {
        PersistentHUD.instance?.SetObjectiveText("Objetivo completado, regresa al lobby");
        Invoke(nameof(ReturnToLobby), 2f); // espera para simular efecto
    }

    void ReturnToLobby()
    {
        SceneManager.LoadScene(lobbySceneName);
    }
}
