using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBreaker : MonoBehaviour
{
    [SerializeField] CrateHandler ch;
    [SerializeField] int crateID;

    bool canBreak;

    public void setHandler (CrateHandler _ch)
    {
        ch = _ch;
        canBreak = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            ch.breakCrate(gameObject);
            canBreak = false;
        }
    }

    public void setID(int i)
    {
        crateID = i;
    }
    public int getID()
    {
        return crateID;
    }
}
