using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{
    bool isShaking = false;
    private float shakeTimeLeft = 0f;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin shaker;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        shaker = virtualCamera.AddCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (shakeTimeLeft > 0f && isShaking)
        {
            shakeTimeLeft -= Time.deltaTime;
        }
        if (shakeTimeLeft <= 0f && isShaking)
        {
            StopShakeCamera();
            shakeTimeLeft = 0f;
        }
    }

    public void ShakeCamera(float frequency, float amplitude, float time)
    {
        shaker.m_FrequencyGain = frequency;
        shaker.m_AmplitudeGain = amplitude;
        shakeTimeLeft = time;

        isShaking = true;
    }

    private void StopShakeCamera()
    {
        isShaking = false;
        shaker.m_AmplitudeGain = 0f;
        shaker.m_FrequencyGain = 0f;
    }
}
