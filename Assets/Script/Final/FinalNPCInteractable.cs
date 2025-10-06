using UnityEngine;

public class FinalNPCInteractable : WorldInteractable
{
    public LevelManager lobbyManager;

    private void Start()
    {
        levelManager = lobbyManager;
    }

    public override void Interact()
    {
        base.Interact();

        // Mensaje de felicitación
        PersistentHUD.instance?.SetObjectiveText("¡Felicidades! Has cumplido tus objetivos");

        // Aquí puedes añadir animación, sonido o efectos si quieres
        lobbyManager.EndGame();
    }
}