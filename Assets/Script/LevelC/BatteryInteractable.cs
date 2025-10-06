using UnityEngine;

public class BatteryInteractable : WorldInteractable
{
    public LevelManagerC managerC;

    private bool pickedUp = false;

    private void Start()
    {
        levelManager = managerC;
    }

    public override void Interact()
    {
        if (pickedUp) return;
        pickedUp = true;

        Debug.Log("Batería recogida");
        gameObject.SetActive(false); // simula que la recoges

        if (managerC != null)
        {
            managerC.OnBatteryPickedUp();
        }
    }
}
