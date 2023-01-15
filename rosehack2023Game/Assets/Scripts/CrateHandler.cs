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
    [SerializeField] bool funCap;
    [SerializeField] bool canSpawn;
    [SerializeField] Vector3 nextCratePos;
    [SerializeField] bool isLeftPlayer;
    [SerializeField] float spawnSpacing;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;

    [Header("Camera Shake")]
    [SerializeField]
    float frequency;
    [SerializeField]
    float amplitude;
    [SerializeField]
    float time;

    GameObject crateHolder;

    void Awake(){
        numCrates = 0;
        nextCratePos = transform.position;
        canSpawn = true;
    }

    void Update()
    {
        transform.position = new Vector3(playerHolder.transform.position.x, transform.position.y, playerHolder.transform.position.z);
        nextCratePos = new Vector3(transform.position.x, nextCratePos.y, transform.position.z);
        if(nextCratePos.y <= minHeight){
            nextCratePos = new Vector3(transform.position.x, minHeight, transform.position.z);
        }else if(nextCratePos.y >= maxHeight || numCrates == 10){
            if(funCap && numCrates >= 10){
                canSpawn = false;
                return;
            }else{
                nextCratePos = new Vector3(transform.position.x, maxHeight, transform.position.z);
            }
        }else{
            canSpawn = true;
        }
    }


    public void addCrate(){
        if(!canSpawn) return; 
        crateHolder = Instantiate(crate, nextCratePos, Quaternion.identity);
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
        risingCamera.GetComponent<CameraShaker>().ShakeCamera(frequency, amplitude, time);

    }


    public int getNumCrates()
    {
        return numCrates;
    }



}
