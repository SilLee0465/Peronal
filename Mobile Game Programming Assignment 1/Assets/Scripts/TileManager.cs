using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject defaultTile;
    [SerializeField] private List<GameObject> tiles = new List<GameObject>();

    private GameObject previousTile;
    private GameObject currentTile;
    private GameObject triggerPoint;
    private Transform nextSpawnpoint;

    private int randomTile;

    // Start is called before the first frame update
    void Start()
    {
        currentTile = defaultTile;
        nextSpawnpoint = defaultTile.transform.GetChild(0);
        triggerPoint = defaultTile.transform.GetChild(1).gameObject;
    }

    void SpawnTile() //make spawnEasyTiles, spawnHardTiles, spawnMediumTiles (same concept as this)
    {
        randomTile = (Random.Range(0, tiles.Count));

        previousTile = currentTile;
        GameObject futureTile = Instantiate(tiles[randomTile], nextSpawnpoint.position, Quaternion.identity);
        currentTile = futureTile;
        nextSpawnpoint = futureTile.transform.GetChild(0);
        triggerPoint = futureTile.transform.GetChild(1).gameObject;
    }

    void DestroyTile()
    { 
        Destroy(previousTile);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == triggerPoint)
        {
            SpawnTile();
        }
        if(other.gameObject.name == "DeletePoint")
        {
            DestroyTile();
        }
    }
}
