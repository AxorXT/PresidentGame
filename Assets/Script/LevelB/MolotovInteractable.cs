using UnityEngine;

public class MolotovInteractable : WorldInteractable
{
    public LevelManagerB managerB;

    private void Start()
    {
        levelManager = managerB; // guarda la referencia gen�rica
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Molotov recogida!");

        gameObject.SetActive(false);

        if (managerB != null)
            managerB.RegisterMolotovPickup();
    }
}
