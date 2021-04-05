using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject buildingButtons;

    public TextMeshProUGUI foodAndMetalText;
    public TextMeshProUGUI oxygenAndEnergyText;
    public TextMeshProUGUI currentTurnText;

    public static UI instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void OnEndTurnButton()
    {
        GameManager.instance.EndTurn();
    }

    public void ToggleBuildingButtons (bool toggle)
    {
        buildingButtons.SetActive(toggle);
    }

    public void OnClickSolarPanelButton()
    {
        GameManager.instance.SetPlacingBuilding(BuildingType.SolarPanel);
        ToggleBuildingButtons(false);
    }

    public void OnClickGreenhouseButton()
    {
        GameManager.instance.SetPlacingBuilding(BuildingType.Greenhouse);
        ToggleBuildingButtons(false);
    }

    public void OnClickMineButton()
    {
        GameManager.instance.SetPlacingBuilding(BuildingType.Mine);
        ToggleBuildingButtons(false);
    }

    public void UpdateUI()
    {
        string food = string.Format("{0} ({1}{2})", GameManager.instance.currentFood, GameManager.instance.foodPerTurn < 0 ? "" : "+", GameManager.instance.foodPerTurn);
        string metal = string.Format("{0} ({1}{2})", GameManager.instance.currentMetal, GameManager.instance.metalPerTurn < 0 ? "" : "+", GameManager.instance.metalPerTurn);
        string oxygen = string.Format("{0} ({1}{2})", GameManager.instance.currentOxygen, GameManager.instance.oxygenPerTurn < 0 ? "" : "+", GameManager.instance.oxygenPerTurn);
        string energy = string.Format("{0} ({1}{2})", GameManager.instance.currentEnergy, GameManager.instance.energyPerTurn < 0 ? "" : "+", GameManager.instance.energyPerTurn);

        foodAndMetalText.text = food + "\n" + metal;
        oxygenAndEnergyText.text = oxygen + "\n" + energy;

        currentTurnText.text = "Turn " + GameManager.instance.currentTurn;
    }
}
