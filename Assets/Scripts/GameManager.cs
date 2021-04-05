using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentTurn;
    public bool placingBuilding;
    public BuildingType currentSelectedBuilding;

    [Header("Current Resources")]
    public int currentFood;
    public int currentMetal;
    public int currentOxygen;
    public int currentEnergy;

    [Header("Round Resource Increase")]
    public int foodPerTurn;
    public int metalPerTurn;
    public int oxygenPerTurn;
    public int energyPerTurn;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UI.instance.UpdateUI();
    }

    public void EndTurn()
    {
        currentFood += foodPerTurn;
        currentMetal += metalPerTurn;
        currentOxygen += oxygenPerTurn;
        currentEnergy += energyPerTurn;

        currentTurn++;

        UI.instance.UpdateUI();

        UI.instance.ToggleBuildingButtons(true);

    }

    public void SetPlacingBuilding(BuildingType buildingType)
    {
        placingBuilding = true;
        currentSelectedBuilding = buildingType;

    }

    public void OnCreatedNewBuilding(Building building)
    {
        if (building.doesProduceResource)
        {
            switch(building.productionResource)
            {
                case ResourceType.Food:
                    foodPerTurn += building.productionResourcePerTurn;
                    break;

                case ResourceType.Metal:
                    metalPerTurn += building.productionResourcePerTurn;
                    break;

                case ResourceType.Oxygen:
                    oxygenPerTurn += building.productionResourcePerTurn;
                    break;

                case ResourceType.Energy:
                    energyPerTurn += building.productionResourcePerTurn;
                    break;

            }
        }

        if (building.hasMaintenanceCost)
        {
            switch (building.maintenanceResource)
            {
                case ResourceType.Food:
                    foodPerTurn += building.maintenanceResourcePerTurn;
                    break;

                case ResourceType.Metal:
                    metalPerTurn += building.maintenanceResourcePerTurn;
                    break;

                case ResourceType.Oxygen:
                    oxygenPerTurn += building.maintenanceResourcePerTurn;
                    break;

                case ResourceType.Energy:
                    energyPerTurn += building.maintenanceResourcePerTurn;
                    break;

            }
        }

        placingBuilding = false;

        UI.instance.UpdateUI();
    }
}
