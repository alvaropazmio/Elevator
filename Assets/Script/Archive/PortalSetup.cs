using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//First attempt of Magic Elevator using Texture Projections
public class PortalSetup : MonoBehaviour
{
    [SerializeField]
    private Camera cameraB;
    [SerializeField]
    private Material cameraMatB;
    [SerializeField]
    private RenderTexture renderTexture;

    public static PortalSetup Instance { set; get; }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        //GameManager.Instance.OnSceneLoaded.AddListener(GetCameraB);
    }

    private void GetCameraB()
    {
        cameraB = GameObject.FindGameObjectWithTag("CameraB").GetComponent<Camera>();
        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(XRSettings.eyeTextureDesc);
        renderTexture.vrUsage = VRTextureUsage.TwoEyes;

        cameraMatB.mainTexture = cameraB.targetTexture;
    }
}
