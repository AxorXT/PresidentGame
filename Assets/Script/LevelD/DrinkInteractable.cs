using UnityEngine;

public class DrinkInteractable : WorldInteractable
{
    public LevelManagerD managerD;
    private bool collected = false;

    private void Start()
    {
        levelManager = managerD;
    }

    public override void Interact()
    {
        if (collected) return;
        collected = true;

        Debug.Log("Bebida recogida");
        gameObject.SetActive(false);

        if (managerD != null)
            managerD.OnDrinkCollected();
    }
}
