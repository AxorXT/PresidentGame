using UnityEngine;

public class ExitDoorInteractable : WorldInteractable
{
    public override void Interact()
    {
        base.Interact();

        LevelManagerA managerA = levelManager as LevelManagerA;
        if (managerA != null)
        {
            managerA.OnExitDoorInteract();
        }
        else
        {
            Debug.LogWarning("LevelManagerA no asignado correctamente en " + gameObject.name);
        }
    }
}