using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    [Header("Object Assignment")]
    [SerializeField] Rigidbody rb;


    [Header("Player Stats")]
    [SerializeField] float playerSpeed;

    //Private Variables
    private Controls controls;
    private Vector2 inputP1;
    private Vector2 inputP2;

    void Awake()
    {
        controls = new Controls();
    }

    // Update is called once per frame
    void Update()
    {
        inputP1 = controls.Player1.Movement.ReadValue<Vector2>();
        rb.velocity = new Vector3(playerSpeed*inputP1.x, 0, playerSpeed*inputP1.y);
    }

    void OnEnable()
    {
        controls.Player1.Enable();
    }

    void OnDisable(){
        controls.Player1.Disable();
    }

}
