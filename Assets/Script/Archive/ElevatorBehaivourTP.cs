using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//First attempt of Magic Elevator using Texture Projections
public class ElevatorBehaivourTP : MonoBehaviour
{
    //private GameManager _gameManager;
    private Scene elevatorScene;

    [SerializeField]
    private GameObject otherElevator;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {

        //_gameManager = GameManager.Instance;

        elevatorScene = this.gameObject.scene;
        player = GameObject.Find("XR Origin");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");

            TransportPlayer(player);
            //PlayEnterAnimations();
            UnloadStartingScene();
            //LoadTargetScene();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //PlayExitAnimations();
            //_gameManager.UnloadScene(elevatorScene.buildIndex);
        }
    }

    private void TransportPlayer(GameObject _player)
    {
        _player.transform.position = otherElevator.transform.position;
    }

    private void UnloadStartingScene()
    {
        //Unloads Scene A by checking all scenes, setting aside the scenes that are not loaded 
        //and the elevator scene
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene _scene = SceneManager.GetSceneByBuildIndex(i);
            if (_scene.isLoaded && _scene != elevatorScene)
            {
                //_gameManager.UnloadScene(_scene.buildIndex);
                Debug.Log("Unloading scene number = " + i);
            }

        }
    }
    /*
    private void LoadTargetScene()
    {
        // Loads scene B by recieving the input of which scene the player wants
        // at the moment just loads scene 2;
        _gameManager.LoadScene(2);
    }*/
}
