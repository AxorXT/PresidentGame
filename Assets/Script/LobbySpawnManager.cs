using UnityEngine;

public class LobbySpawnManager : MonoBehaviour
{
    public Transform lobbySpawnPoint;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null && lobbySpawnPoint != null)
        {
            CharacterController controller = player.GetComponent<CharacterController>();

            // Desactivar momentáneamente el CharacterController para mover al player sin conflicto
            if (controller != null)
                controller.enabled = false;

            player.transform.position = lobbySpawnPoint.position;
            player.transform.rotation = lobbySpawnPoint.rotation;

            if (controller != null)
                controller.enabled = true;
        }
    }
}
