using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public CrateHandler cH;
    public Player_Controls pC;
    int numCrates;
    float walkTimer;
    float rotation = 0;
    Transform t;
    float dir;
    // Start is called before the first frame update
    void Start()
    {
        numCrates = cH.getNumCrates();
        walkTimer = 0;
        t = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        walkTimer = pC.getWalkTimer();
        dir = pC.getDirection();
        numCrates = cH.getNumCrates();
        Quaternion target;
        
        if(walkTimer > 0.1f)
        {
            float r = Random.Range(0.00f, 2f);
            rotation = numCrates / 2 * walkTimer * walkTimer + numCrates * walkTimer - 2 + r;
            rotation *= dir;
            Debug.Log(walkTimer + " : " + numCrates);
            target = Quaternion.Euler(0,0,rotation);
        }
        else{
            target = Quaternion.Euler(0,0,0);
            
        }
        t.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        
    }
}
