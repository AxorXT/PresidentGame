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

        Debug.Log("Bater�a puesta en la piscina");

        // Aqu� puedes a�adir efecto visual: chispa o burbuja
        if (managerC != null)
        {
            managerC.OnBatteryPlaced();
        }
    }
}
