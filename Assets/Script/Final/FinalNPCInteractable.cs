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

        // Mensaje de felicitaci�n
        PersistentHUD.instance?.SetObjectiveText("�Felicidades! Has cumplido tus objetivos");

        // Aqu� puedes a�adir animaci�n, sonido o efectos si quieres
        lobbyManager.EndGame();
    }
}