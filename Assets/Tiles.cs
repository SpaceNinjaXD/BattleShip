using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public bool cannonHit = false;
    public bool isShipTile = false;
    public Material MissHit;
    public Material SuccHit;
    public Transform subPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cannonHit == true)
            if(isShipTile == true)
            {
                this.gameObject.GetComponent<Renderer>().material = SuccHit;
            }else
                this.gameObject.GetComponent<Renderer>().material = MissHit;
    }
}
