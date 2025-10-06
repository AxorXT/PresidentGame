using UnityEngine;

public class PoolInteractable : WorldInteractable
{
    public LevelManagerC managerC;

    private bool batteryInserted = false;

    private void Start()
    {
        levelManager = managerC;
    }

    public override void Interact()
    {
        if (!managerC.BatteryCollected || batteryInserted) return;

        batteryInserted = true;

        Debug.Log("Batería puesta en la piscina");

        // Aquí puedes añadir efecto visual: chispa o burbuja
        if (managerC != null)
        {
            managerC.OnBatteryPlaced();
        }
    }
}
