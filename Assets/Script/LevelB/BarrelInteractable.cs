using UnityEngine;

public class BarrelInteractable : WorldInteractable
{
    public LevelManagerB managerB;

    private void Start()
    {
        levelManager = managerB;
    }

    public override void Interact()
    {
        if (managerB != null)
            managerB.OnBarrelInteract();
    }
}
