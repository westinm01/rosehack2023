using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTweener : MonoBehaviour
{
    [Header("Object Assignment")]
    [SerializeField] GameObject button;


    void OnMouseOver(){
        Debug.Log("mouseOn");
        LeanTween.scale(button, Vector3.one*1.25f, 0.25f).setEaseOutBack();
    }

    void OnMouseExit(){
        Debug.Log("mouseOff");
        LeanTween.scale(button, Vector3.one, 0.25f).setEaseInExpo();
    }

}
