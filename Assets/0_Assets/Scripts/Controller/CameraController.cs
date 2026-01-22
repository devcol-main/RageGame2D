using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera followCam;
    
    //[SerializeField] 
    private float followCamSize;

    public void SetFollowCamSize(float followCamSize)
    {
        followCam.Lens.OrthographicSize = followCamSize;
    }

   

}
