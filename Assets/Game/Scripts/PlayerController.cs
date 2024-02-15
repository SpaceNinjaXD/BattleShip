using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    public GameObject cannon;
    public CannonController cannonController;
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }



    void Update()
    {
        Vector2 movementInput = _playerInputs.Touchpad.Move.ReadValue<Vector2>();
        
        
        cannonController.RotateCannon(movementInput);

        

        // Fire the Cannon
        if (_playerInputs.Touchpad.Fire.triggered)
        {

            cannonController.FireCannon();
        }

        
    }
}

