using UnityEngine;
using System.Collections;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private CinemachineBasicMultiChannelPerlin m_cameraNoise;

    public void SetPlayer(Transform player)
    {
        virtualCamera.Follow = player;
        virtualCamera.LookAt = player;
        m_cameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void CameraShake() => StartCoroutine(StartCameraShake());

    private IEnumerator StartCameraShake()
    {
        m_cameraNoise.m_AmplitudeGain = 1.3f;
        yield return new WaitForSeconds(0.2f);
        m_cameraNoise.m_AmplitudeGain = 0;
    }
}