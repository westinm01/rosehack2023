using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBreaker : MonoBehaviour
{

    [SerializeField] CrateHandler ch;
    [SerializeField] int crateID;

    bool canBreak;

    public void setHandler(CrateHandler _ch){
        ch = _ch;
        canBreak = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" && canBreak)
        {
            // Debug.Log("TOUCHING GrOUND AAAAAAAAAAAAAAAAAAAAAA");
            ch.breakCrate(gameObject);
            canBreak = false;
            FindObjectOfType<SFXPlayer>().PlayBreakCrateSFX();
        }
    }

    public void setID(int i){
        crateID = i;
    }


    public int getID(){
        return crateID;
    }

}
