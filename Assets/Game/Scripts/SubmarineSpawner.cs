using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineSpawner : MonoBehaviour
{
    public GameController gController;
    private int numOfTiles;
    private int numOfSubs;
    public List<GameObject> SpawnedSubmarines;

    private GameObject sub;
    private int spawnedSubs = 0;
    private void Awake()
    {
        numOfTiles = gController.tiles.Count;
        numOfSubs = gController.submarines.Count;
        Debug.Log(numOfSubs);
    }

    public void SpawnSubs()
    {
        Debug.Log("Starting to Spawn Submarines");
        while (spawnedSubs < numOfSubs)
        {
            int tileChosen = Random.Range(0, numOfTiles - 1);
            Debug.Log(tileChosen + "Index number");
            Transform pos = gController.tiles[tileChosen].GetComponentInChildren<Transform>();
            gController.tiles.RemoveAt(tileChosen);
            numOfTiles = gController.tiles.Count;
            sub = Instantiate(gController.submarines[spawnedSubs],pos.position, Quaternion.Euler(0, 90*Random.Range(0,3), 0));
            SpawnedSubmarines.Add(sub);
            spawnedSubs += 1;
        }
    }

    


}
