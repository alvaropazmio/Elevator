/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Hub of all actions the Elevator performs after its spawning
and up to its destruction.
Dependencies: -
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaivour : MonoBehaviour
{
    [SerializeField] List<GameObject> elevatorShells;

    private GameObject startShell;
    private GameObject destinationShell;


    [SerializeField]
    GameObject startStencil;
    [SerializeField]
    GameObject destinationStencil;

    Material startStencilMat;
    Material destinationStencilMat;

    private string shaderStencilID = "_StencilID";


    private void Awake()
    {
        startStencilMat = startStencil.GetComponent<Renderer>().material;
        destinationStencilMat = destinationStencil.GetComponent<Renderer>().material;
    }


    private void OnEnable()
    {
        Actions.OnElevatorSpawned += SetupElevator;
        Actions.OnPlayerEntered += PlayerEnters;
        Actions.OnDoorsClosed += DestroyElevator;
    }

    private void OnDisable()
    {
        Actions.OnElevatorSpawned -= SetupElevator;
        Actions.OnPlayerEntered -= PlayerEnters;
        Actions.OnDoorsClosed -= DestroyElevator;
    }

    private void SetupElevator(Key keyRef, GameObject elevatorRef)
    {
        SetElevatorStencils(keyRef);
        SetShellLayers(keyRef);
    }


    private void SetElevatorStencils(Key keyRef)
    {
        startStencilMat.SetInt(shaderStencilID, keyRef.startStencilIndex);
        destinationStencilMat.SetInt(shaderStencilID, keyRef.destinationStencilIndex);
    }

    private void SetShellLayers(Key keyRef)
    {
        foreach (GameObject shell in elevatorShells)
        {
            if (shell.activeInHierarchy) startShell = shell;
            else destinationShell = shell;
        }

        startShell.layer = keyRef.startLayerIndex;
        destinationShell.layer = keyRef.destinationLayerIndex;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerReferences playerRefs = other.GetComponent<PlayerReferences>();

            if (playerRefs != null)
            {
                Actions.OnPlayerEntered.Invoke(playerRefs);
                
            }
        }
    }

    private void PlayerEnters(PlayerReferences playerRefs)
    {
        ChangePlayerStencil(playerRefs);
        toggleShells();
    }

    private void ChangePlayerStencil(PlayerReferences playerRefs)
    {

        Material playerStencilMat = playerRefs.stencilMaterial;

        int currentStencilIndex = playerStencilMat.GetInt(shaderStencilID);
        
        int activeKeyStart = KeyChain.activeKey.startStencilIndex;
        int activeKeyDestination = KeyChain.activeKey.destinationStencilIndex;

        if (currentStencilIndex == activeKeyStart)
        {
            playerStencilMat.SetInt(shaderStencilID, activeKeyDestination);
        }
        else if (currentStencilIndex == activeKeyDestination)
        {
            playerStencilMat.SetInt(shaderStencilID, activeKeyStart);
        }

    }

    private void toggleShells()
    {

        foreach (GameObject shell in elevatorShells)
        {
            shell.SetActive(!shell.activeInHierarchy);
        }

    }



    private void DestroyElevator(Key activeKey)
    {
        Destroy(this.transform.parent.gameObject);
    }
}
