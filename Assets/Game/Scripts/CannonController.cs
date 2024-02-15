using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float FiringPower = 5;

    public GameObject CannonBase;
    public GameObject Cannonball;
    public Transform ShootingPos;

    public GameObject Explosion;
    public AudioSource audible;

    public bool hasFired = false;
    public CannonBall _CanBall;

    private void Start()
    {
        hasFired = false;
    }
    public void FireCannon()
    {

        audible.Play();
        GameObject CreatedCannonball = Instantiate(Cannonball, ShootingPos.position, ShootingPos.rotation);
        CreatedCannonball.GetComponent<Rigidbody>().velocity = ShootingPos.transform.up * FiringPower;
        _CanBall = CreatedCannonball.GetComponent<CannonBall>();
        Destroy(Instantiate(Explosion, ShootingPos.position, ShootingPos.rotation), 2);
        Debug.Log(_CanBall);
        hasFired = true;
    }
    
    public void RotateCannon(Vector2 newRot)
    {
        CannonBase.transform.rotation = Quaternion.Euler(CannonBase.transform.rotation.eulerAngles +
            new Vector3(0, newRot.x * rotationSpeed, newRot.y * rotationSpeed));
    }

    private void Update()
    {
        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VericalRotation = Input.GetAxis("Vertical");
        
        //CannonBase.transform.rotation = Quaternion.Euler(CannonBase.transform.rotation.eulerAngles +
           // new Vector3(0, HorizontalRotation * rotationSpeed, VericalRotation * rotationSpeed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireCannon();
            
        }
    }
}
