using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour
{
    [Header("Object Assignment")]
    [SerializeField] List<GameObject> stack;
    [SerializeField] GameObject crate;
    [SerializeField] GameObject playerHolder;
    
    //Private Vars
    [SerializeField] int numCrates;
    [SerializeField] Vector3 nextCratePos;
    [SerializeField] bool isLeftPlayer;
    GameObject crateHolder;

    void Awake(){
        numCrates = 0;
        nextCratePos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(playerHolder.transform.position.x, transform.position.y, playerHolder.transform.position.z);
        nextCratePos = new Vector3(transform.position.x, nextCratePos.y, transform.position.z);
    }


    public void addCrate(){
        crateHolder = Instantiate(crate, nextCratePos, Quaternion.identity);
        // crateHolder.transform.parent = transform;
        crateHolder.GetComponent<CrateBreaker>().setHandler(gameObject.GetComponent<CrateHandler>());
        crateHolder.GetComponent<CrateBreaker>().setID(numCrates);
        stack.Add(crateHolder);
        numCrates++;
        nextCratePos = nextCratePos + new Vector3(0, 1.5f, 0);
    }

    public void removeCrate(){
        if(numCrates <= 0) return;
        Destroy(stack[numCrates-1]);
        stack.RemoveAt(numCrates - 1);
        numCrates--;
        nextCratePos = nextCratePos - new Vector3(0, 1.5f, 0);
    }

    public void dropAll(){
        Debug.Log(numCrates);
        if(numCrates <= 0) return;

        foreach (GameObject crate in stack)
        {
            nextCratePos -= new Vector3(0, 1.5f,0);
            Destroy(crate);
        }
        stack.Clear();

        FindObjectOfType<ScoreSystem>().AddScore(isLeftPlayer, numCrates);
        numCrates = 0;
    }

    public void breakCrate(GameObject currentCrate){
        
        // foreach(GameObject _crate in stack){
        //     if(_crate.GetComponent<CrateBreaker>().getID == crate.GetComponent<CrateBreaker>().getID){
                
        //     }
        // }
        nextCratePos -= new Vector3(0, 1.5f,0);
        stack.RemoveAt(crate.GetComponent<CrateBreaker>().getID());
        Destroy(currentCrate);
    }







}
