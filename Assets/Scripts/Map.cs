using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Tile> tiles = new List<Tile>();
    public List<Building> buildings = new List<Building>();

    public float tileSize;

    public List<Building> buildingPrefabs = new List<Building>();

    public static Map instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EnableUsableTiles();
    }
    public void EnableUsableTiles()
    {
        foreach(Building building in buildings)
        {
            Tile northTile = GetTileAtPosition(building.transform.position + new Vector3(0, tileSize, 0));
            Tile southTile = GetTileAtPosition(building.transform.position + new Vector3(0, -tileSize, 0));
            Tile eastTile = GetTileAtPosition(building.transform.position + new Vector3(tileSize, 0, 0));
            Tile westTile = GetTileAtPosition(building.transform.position + new Vector3(-tileSize, 0, 0));

            northTile?.ToggleHighlight(true);
            southTile?.ToggleHighlight(true);
            eastTile?.ToggleHighlight(true);
            westTile?.ToggleHighlight(true);
        }
    }

    public void DisableUsableTiles()
    {
        foreach(Tile tile in tiles)
        {
            tile.ToggleHighlight(false);
        }
    }

    public void CreateNewBuilding(BuildingType buildingType, Vector3 position)
    {
        Building prefabToSpawn = buildingPrefabs.Find(x => x.type == buildingType);

        GameObject buildingObj = Instantiate(prefabToSpawn.gameObject, position, Quaternion.identity);
        buildings.Add(buildingObj.GetComponent<Building>());

        GetTileAtPosition(position).hasBuilding = true;

        DisableUsableTiles();

        GameManager.instance.OnCreatedNewBuilding(prefabToSpawn);
    }

    Tile GetTileAtPosition(Vector3 position)
    {
        return tiles.Find(x => x.canBeHighlighted(position));
    }
}
