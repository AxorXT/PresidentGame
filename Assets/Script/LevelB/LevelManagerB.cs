using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerB : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject barrel;
    public string lobbySceneName = "Lobby";

    private int molotovsCollected = 0;
    private int totalMolotovs = 5;
    private bool canThrow = false;

    void Start()
    {
        // Reposicionar al jugador al inicio del nivel
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
        }

        // Mostrar texto inicial
        PersistentHUD.instance?.SetObjectiveText("Recolecta los 5 molotovs alrededor del área");
    }

    //Llamado por MolotovInteractable
    public void RegisterMolotovPickup()
    {
        molotovsCollected++;
        PersistentHUD.instance?.SetObjectiveText($"Molotovs recolectados: {molotovsCollected}/{totalMolotovs}");

        if (molotovsCollected >= totalMolotovs)
        {
            canThrow = true;
            PersistentHUD.instance?.SetObjectiveText("Perfecto, lanza un molotov al barril para completar el sabotaje");
        }
    }

    //Llamado por BarrelInteractable
    public void OnBarrelInteract()
    {
        if (canThrow)
        {
            PersistentHUD.instance?.SetObjectiveText("Sabotaje completado — regresa a la salida");
            Invoke(nameof(ReturnToLobby), 2f); // Espera un par de segundos para simular el efecto
        }
        else
        {
            PersistentHUD.instance?.SetObjectiveText("Aún no tienes suficientes molotovs para sabotear");
        }
    }

    void ReturnToLobby()
    {
        SceneManager.LoadScene(lobbySceneName);
    }
}