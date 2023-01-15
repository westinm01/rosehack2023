using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class RisingCamera : MonoBehaviour
{
    [SerializeField]
    private float riseAmount;

    [SerializeField]
    private float riseTime;

    Vector3 origPos;
    Vector3 oldPos;
    Vector3 newPos;
    CinemachineVirtualCamera myCam;
    CinemachineTransposer transposer;
    Coroutine coroutine;

    float timeElapsed = 0f;

    private void Awake()
    {
        myCam = GetComponent<CinemachineVirtualCamera>();
        transposer = myCam.GetCinemachineComponent<CinemachineTransposer>();

        origPos = GetCurrPos();
    }

    public void RaiseCamera(int numCrates)
    {
        timeElapsed = 0f;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(RaiseCamOverTime(numCrates));
    }

    private Vector3 GetCurrPos()
    {   
        return transposer.m_FollowOffset;
    }

    IEnumerator RaiseCamOverTime(int numCrates)
    {
        Vector3 oldPos = GetCurrPos();

        newPos = origPos;
        newPos.y += riseAmount * numCrates;
        Debug.Log(newPos);

        while (timeElapsed < riseTime)
        {
            timeElapsed += Time.deltaTime;

            transposer.m_FollowOffset.y = Mathf.Lerp(oldPos.y, newPos.y, timeElapsed / riseTime);

            yield return null;
        }
        transposer.m_FollowOffset.y = newPos.y;
    }
}
