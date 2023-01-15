using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrateCounter : MonoBehaviour
{
    [SerializeField]
    TMP_Text textField;
    [SerializeField]
    CrateHandler ch;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        textField.text = ch.getNumCrates().ToString();
    }
    
}
