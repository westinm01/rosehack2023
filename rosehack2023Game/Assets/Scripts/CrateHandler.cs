using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour
{
    [Header("Object Assignment")]
    [SerializeField] List<GameObject> stack;
    [SerializeField] GameObject crate;
    [SerializeField] GameObject playerHolder;
    [SerializeField] RisingCamera risingCamera;
    
    //Private Vars
    [SerializeField] int numCrates;
    [SerializeField] Vector3 nextCratePos;
    [SerializeField] bool isLeftPlayer;
    [SerializeField] float spawnSpacing;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    GameObject crateHolder;

    void Awake(){
        numCrates = 0;
        nextCratePos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(playerHolder.transform.position.x, transform.position.y, playerHolder.transform.position.z);
        nextCratePos = new Vector3(transform.position.x, nextCratePos.y, transform.position.z);
        if(nextCratePos.y <= minHeight){
            nextCratePos = new Vector3(transform.position.x, minHeight, transform.position.z);
        }else if(nextCratePos.y >= maxHeight){
            nextCratePos = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
    }


    public void addCrate(){
        crateHolder = Instantiate(crate, nextCratePos, Quaternion.identity);
        // crateHolder.transform.parent = transform;
        crateHolder.GetComponent<CrateBreaker>().setHandler(gameObject.GetComponent<CrateHandler>());
        crateHolder.GetComponent<CrateBreaker>().setID(numCrates);
        stack.Add(crateHolder);
        numCrates++;
        nextCratePos = nextCratePos + new Vector3(0, spawnSpacing, 0);

        risingCamera.RaiseCamera(numCrates);
    }

    public void removeCrate(){
        if(numCrates <= 0) return;
        Destroy(stack[numCrates-1]);
        stack.RemoveAt(numCrates - 1);
        numCrates--;
        nextCratePos = nextCratePos - new Vector3(0, spawnSpacing, 0);
        risingCamera.RaiseCamera(numCrates);

    }

    public void dropAll(){
        Debug.Log(numCrates);
        if(numCrates <= 0) return;

        foreach (GameObject crate in stack)
        {
            nextCratePos -= new Vector3(0, spawnSpacing,0);
            Destroy(crate);
        }
        stack.Clear();

        FindObjectOfType<ScoreSystem>().AddScore(isLeftPlayer, numCrates);
        numCrates = 0;
        Debug.Log("NO CRATES");
        risingCamera.RaiseCamera(numCrates);
    }


    public void breakCrate(GameObject currentCrate){
        
        // foreach(GameObject _crate in stack){
        //     if(_crate.GetComponent<CrateBreaker>().getID == crate.GetComponent<CrateBreaker>().getID){
                
        //     }
        // }
        currentCrate.SetActive(false);
        nextCratePos -= new Vector3(0, spawnSpacing,0);
        Debug.Log("Delete ID: " + currentCrate.GetComponent<CrateBreaker>().getID());
        Debug.Log("numcrates: " + numCrates);
        numCrates--;
        
        foreach(GameObject _crate in stack){
            if(_crate.GetComponent<CrateBreaker>().getID() > currentCrate.GetComponent<CrateBreaker>().getID() ){
                _crate.GetComponent<CrateBreaker>().setID(_crate.GetComponent<CrateBreaker>().getID() - 1);
            }
        }

        stack.RemoveAt(currentCrate.GetComponent<CrateBreaker>().getID());
        
        Destroy(currentCrate,0.05f);

        risingCamera.RaiseCamera(numCrates);

        //stack.RemoveAt(crate.GetComponent<CrateBreaker>().getID());
        //Destroy(currentCrate,0.05f);
    }


    public int getNumCrates()
    {
        return numCrates;
    }







}
