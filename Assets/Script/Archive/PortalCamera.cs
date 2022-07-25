using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    private GameObject mainCamera;
    private Vector3 mainCamPos;
    
    [SerializeField]
    private Transform portalElevator;
    [SerializeField]
    private Transform portalWorld;



    private void Awake()
    {
        this.GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.Both;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }


    private void Update()
    {
        mainCamPos = mainCamera.transform.position;

        UpdatePosition();
        UpdateRotation();
        
    }


    private void UpdatePosition()
    {


        float playerOffsetX = mainCamPos.x - portalWorld.position.x;
        float playerOffsetZ = mainCamPos.z - portalWorld.position.z;


        Vector3 playerOffsetFromPortal = new Vector3(playerOffsetX, mainCamPos.y, playerOffsetZ);


        transform.position = portalElevator.position + playerOffsetFromPortal;
    }

    private void UpdateRotation()
    {
        float angularDifference = Quaternion.Angle(portalElevator.rotation, portalWorld.rotation);

        Quaternion portalRotationalDif = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCamDirection = portalRotationalDif * mainCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }
}
