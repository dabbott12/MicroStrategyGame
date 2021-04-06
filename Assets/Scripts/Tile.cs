using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject highlight;
    public bool hasBuilding;
    public bool isEnabled;

    private void Awake()
    {
        isEnabled = false;
    }

    public void ToggleHighlight(bool toggle)
    {
        highlight.SetActive(toggle);
        this.isEnabled = toggle;
    }

    public bool canBeHighlighted(Vector3 potentialPosition)
    {
        return transform.position == potentialPosition && !hasBuilding;
    }

    private void OnMouseDown()
    {
        if(GameManager.instance.placingBuilding && !hasBuilding)
        {
            Map.instance.CreateNewBuilding(GameManager.instance.currentSelectedBuilding, transform.position);
        }
    }
}
