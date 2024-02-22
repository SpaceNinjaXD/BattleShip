using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarines : MonoBehaviour
{
    public int subSize;
    public GameObject art;
    public int timesRotated = 0;
    List<GameObject> touchingTiles = new List<GameObject>();
    public GameObject gameController;
    public bool isLegal = false;
    public bool hasSunk = false;
    // Start is called before the first frame update
    private void Awake()
    {
        gameController = GameObject.Find("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tile"))
        {

            if (other.gameObject.GetComponent<Tiles>().isShipTile == false)
            {
                touchingTiles.Add(other.gameObject);
                other.gameObject.GetComponent<Tiles>().isShipTile = true;

            }
            
        }
    }


    public void checkLegality()
    {
        if (touchingTiles.Count != subSize)
        {
            RotateSub();
        }  
        else
        {
            foreach (GameObject tile in touchingTiles)
            {
                if (tile.GetComponent<Tiles>().isShipTile)
                    RotateSub();
                break;
            }
            foreach (GameObject tile in touchingTiles)
            {
                tile.GetComponent<Tiles>().isShipTile = true;
            }
            isLegal = true;
        }



    }
    public bool isOnBoard()
    {
        return touchingTiles.Count == subSize;
    }

    public void RotateSub()
    {
        if(timesRotated < 4)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            touchingTiles.Clear();
            this.gameObject.transform.Rotate(0, 90, 0);
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            timesRotated += 1;
        }
        else
        {
            teleportSub();
        }
        
    }

    public void teleportSub()
    {
        GameController gScript = gameController.GetComponent<GameController>();
        int randTile = Random.Range(0, gScript.tiles.Count - 1);
        Transform pos = gScript.tiles[randTile].GetComponentInChildren<Transform>();
        this.gameObject.transform.position = pos.position;
        timesRotated = 0;
    }
    void Start()
    {
        Debug.Log("Ship has Spawned");
    }

    public void checkIfSunk()
    {
        int tileHit = 0;
        foreach(GameObject tile in touchingTiles)
        {
            if (tile.GetComponent<Tiles>().cannonHit)
            {
                tileHit += 1;
            }
        }
        if(touchingTiles.Count == tileHit)
        {
            hasSunk = true;
        }
    }


}
