using Unity.Cinemachine;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    private CinemachineCamera cinemachineCamera;

    private void Awake()
    {
        cinemachineCamera = FindFirstObjectByType<CinemachineCamera>();
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
    }

    private void Start()
    {
        
    }
}
