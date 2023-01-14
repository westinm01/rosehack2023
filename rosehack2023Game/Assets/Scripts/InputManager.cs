using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Object Assignment")]
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;


    [Header("Player Stats")]


    //Private Vars
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
        inputP2 = controls.Player2.Movement.ReadValue<Vector2>();   

        player1.GetComponent<Player_Controls>().updateInput(inputP1);
        player2.GetComponent<Player_Controls>().updateInput(inputP2);

    }

    void OnEnable()
    {
        controls.Player1.Enable();
        controls.Player2.Enable();
    }

    void OnDisable(){
        controls.Player1.Disable();
        controls.Player2.Disable();
    }

}
