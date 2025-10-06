using UnityEngine;

public class CoolerInteractable : WorldInteractable
{
    public LevelManagerD managerD;
    private bool stolen = false;

    private void Start()
    {
        levelManager = managerD;
    }

    public override void Interact()
    {
        if (stolen || managerD.DrinksCollected < 2) return;

        stolen = true;

        Debug.Log("Hielera robada");
        gameObject.SetActive(false);

        if (managerD != null)
            managerD.OnCoolerStolen();
    }
}