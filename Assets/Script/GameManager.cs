/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Main Manager of the Elevator System, 
Mostly manages the scene loading and unloading.
Dependencies: this.GameObject is Prefab/Managers which has to be
assigned in ManagerInstantiation in the Inspector. 
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> NotToDestroy;
    [SerializeField]
    List<GameObject> XRObjects;

    private bool setup = false;

    private void Awake()
    {
        if (!setup)
        {
            Setup();
        }
    }

    private void Setup()
    {
        foreach (GameObject xrGO in XRObjects)
        {
            if (!NotToDestroy.Contains(xrGO))
            {
                Instantiate(xrGO);
                NotToDestroy.Add(xrGO);
            }
        }

        GameObject XRmanager;
        XRmanager = FindObjectOfType<XRInteractionManager>().gameObject;
        NotToDestroy.Add(XRmanager);

        foreach (GameObject go in NotToDestroy)
        {
            if (!go.GetComponent<DontDestroyScript>())
            {
                go.AddComponent<DontDestroyScript>();
            }
        }

        setup = true;
    }


    private void OnEnable()
    {
        Actions.OnElevatorSpawned += AddActiveKey;
        Actions.OnElevatorSpawned += LoadScene;
        Actions.OnDoorsClosed += UnloadScene;
    }

    private void OnDisable()
    {
        Actions.OnElevatorSpawned -= AddActiveKey;
        Actions.OnElevatorSpawned -= LoadScene;
        Actions.OnDoorsClosed -= UnloadScene;
    }

    private void AddActiveKey(Key keyRef, GameObject elevatorRef)
    {
        KeyChain.activeKey = keyRef;
    }


    private void LoadScene (Key keyRef, GameObject elevatorRef)
    {

        string sceneName = keyRef.destinationSceneName;
        Scene scene = SceneManager.GetSceneByName(sceneName);

        if (!scene.isLoaded)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            StartCoroutine(WaitAndMove(keyRef, elevatorRef));
        }
    }

    //Unity needs a bit of time to Load a new Scene completely.
    //If it's not completely loaded, ScenePivot can't be found.
    IEnumerator WaitAndMove(Key keyRef, GameObject elevatorRef)
    {
        yield return new WaitForSeconds(0.5f);
        MoveSceneToElevator(keyRef.destinationSceneName, elevatorRef);
    }

    private void MoveSceneToElevator(String sceneName, GameObject elevator)
    {
        ScenePivot[] activePivots = FindObjectsOfType<ScenePivot>();

        for (int i = 0; i <= activePivots.Length - 1; i++)
        {
            if (activePivots[i].sceneName == sceneName)
            {
                GameObject destinationPivot = activePivots[i].gameObject;
                destinationPivot.transform.position = elevator.transform.position;
                destinationPivot.transform.rotation = elevator.transform.rotation;
            }
        }
    }


    public void UnloadScene (Key keyRef)
    {
        Scene scene = SceneManager.GetSceneByName(keyRef.startSceneName);
        if (scene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }   
}
