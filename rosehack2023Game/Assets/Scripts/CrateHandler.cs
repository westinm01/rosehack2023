using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour
{
    [Header("Object Assignment")]
    [SerializeField] List<GameObject> stack;
    [SerializeField] GameObject crate;
    
    //Private Vars
    int numCrates;
    [SerializeField] Vector3 nextCratePos;

    void Awake(){
        numCrates = 0;
    }


    public void addCrate(){
        stack.Add(Instantiate(crate, nextCratePos, Quaternion.identity));
        numCrates++;
        nextCratePos = nextCratePos + new Vector3(0, 1.5f, 0);
    }

    public void removeCrate(){
        stack.RemoveAt(numCrates - 1);
        numCrates--;
        nextCratePos = nextCratePos - new Vector3(0, 1.5f, 0);
    }







}
