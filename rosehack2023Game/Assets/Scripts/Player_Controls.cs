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
    private Vector2 input;

    void Awake()
    {
        controls = new Controls();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector3(playerSpeed*input.x, 0, 0);
    }

    public void updateInput(Vector2 _input)
    {
        input = _input;
    }

    void OnEnable()
    {
        // controls.Player1.Enable();
    }

    void OnDisable(){
        // controls.Player1.Disable();
    }

}
