using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject Explosion;
    public bool hasHit = false;
    public Collision col;
    /*private void Awake()
    {
        FindObjectOfType<GameController>().
    }*/
    public void Des()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != 3)
        {
            Debug.Log(collision.gameObject);
            Destroy(Instantiate(Explosion, transform.position, transform.rotation), 2);
            hasHit = true;
            Debug.Log(hasHit);
            col = collision;
            if(col.gameObject.GetComponent<Tiles>().isShipTile == true && col.gameObject.GetComponent<Tiles>().firstHit == false)
            {
                GameObject.Find("GameController").GetComponent<GameController>().SubsLeft -= 1;
                col.gameObject.GetComponent<Tiles>().firstHit = true;
            }
        }
        
            
        
    }

    
}
