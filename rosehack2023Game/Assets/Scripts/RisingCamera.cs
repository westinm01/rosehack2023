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
    float timeToComplete;

    private void Awake()
    {
        myCam = GetComponent<CinemachineVirtualCamera>();
        transposer = myCam.GetCinemachineComponent<CinemachineTransposer>();

        origPos = GetCurrPos();
    }

    public void RaiseCamera(int numCrates)
    {
        float leftoverTime = 0f;
        if (timeElapsed > 0f)
        {
            leftoverTime = riseTime - timeElapsed;
        }

        timeElapsed = 0f;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(RaiseCamOverTime(numCrates, riseTime + leftoverTime));
    }

    private Vector3 GetCurrPos()
    {   
        return transposer.m_FollowOffset;
    }

    IEnumerator RaiseCamOverTime(int numCrates, float timeToComplete)
    {
        Vector3 oldPos = GetCurrPos();

        newPos = origPos;
        newPos.y += riseAmount * numCrates;
        Debug.Log(newPos);

        while (timeElapsed < timeToComplete)
        {
            timeElapsed += Time.deltaTime;

            transposer.m_FollowOffset.y = Mathf.Lerp(oldPos.y, newPos.y, timeElapsed / timeToComplete);

            yield return null;
        }
        transposer.m_FollowOffset.y = newPos.y;
    }
}
