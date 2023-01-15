using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    [Header("Object Assignment")]
    [SerializeField] Rigidbody rb;
    // [SerializeField] GameObject crate;
    [SerializeField] CrateHandler ch;


    [Header("Player Stats")]
    [SerializeField] float playerSpeed;

    //Private Variables
    private Controls controls;
    private Vector2 input;
    private bool canPickup;
    private float walkTimer;
    // private List<GameObject> stack;

    void Awake()
    {
        controls = new Controls();
        walkTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector3(playerSpeed*input.x, 0, 0);
        if(Mathf.Abs(rb.velocity.x) > 0.001f)
        {
            walkTimer += Time.deltaTime;
        }
        else
        {
            walkTimer = 0;
        }
    }

    public void updateInput(Vector2 _input)
    {
        input = _input;
    }

    public void pickup(){
        if(!canPickup) return;
        ch.addCrate();
        // Debug.Log("Pikceudp1");
        
    }
    
    public void drop(){
        if(!canPickup) return;
        ch.removeCrate();
    }

    public void setCanPickup(bool _pickup){
        canPickup = _pickup;
    }

    public void dropOff(){
        ch.dropAll();
    }

    public float getWalkTimer()
    {
        return walkTimer;
    }

    public float getDirection()
    {
        return input.x;
    }
}
