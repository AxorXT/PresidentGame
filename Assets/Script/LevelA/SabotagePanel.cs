using UnityEngine;

public class SabotagePanel : WorldInteractable
{
    public override void Interact()
    {
        base.Interact();

        LevelManagerA managerA = levelManager as LevelManagerA;
        if (managerA != null)
        {
            managerA.OnSabotageComplete();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("LevelManagerA no asignado correctamente en " + gameObject.name);
        }
    }
}
