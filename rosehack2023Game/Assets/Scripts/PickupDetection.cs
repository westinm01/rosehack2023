using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDetection : MonoBehaviour
{
    
    int isPlayer;

    void Awake(){
        isPlayer = LayerMask.NameToLayer("Player");    
    }
    
    void OnTriggerEnter(Collider col){
        if(col.gameObject.layer != isPlayer) return;


        col.transform.parent.GetComponent<Player_Controls>().setCanPickup(true);
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.layer != isPlayer) return;

        col.transform.parent.GetComponent<Player_Controls>().setCanPickup(false);
    }


}
