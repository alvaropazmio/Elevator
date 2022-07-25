/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Key Monobehaivor to Set-Up the information from 
KeyScriptableObject.
Dependencies: Needs a KeyScriptableObject assigned in the Inspector.
---------------------------------------------------------*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public KeyScriptableObject _key;


    private Scene startScene;
    private Scene destinationScene;

    public string startSceneName;
    public string destinationSceneName;

    public int startStencilIndex;
    public int destinationStencilIndex;

    public int startLayerIndex;
    public int destinationLayerIndex;

    public string startLayerName;
    public string destinationLayerName;

    private Mesh _mesh;
    private Material _mat;

    private GameObject elevator;
    private GameObject mainCamera;

    //place holder for function that checks íf Player is close to the Elevator Spawning area
    public bool playerInRange = false;
    private ProximityCheck _proximityCheck;

    private void Awake()
    {
        GetStartParameters();
        GetDestinationParameters();

        ChangeVisuals();
    }

    private void GetStartParameters()
    {
        startScene = this.gameObject.scene;
        startSceneName = startScene.name;

        startLayerIndex = this.gameObject.layer;
        startLayerName = LayerMask.LayerToName(startLayerIndex);

        startStencilIndex = int.Parse(startLayerName.Replace("St", ""));
    }
    private void GetDestinationParameters()
    {
        destinationSceneName = _key.destinationSceneName;
        destinationScene = SceneManager.GetSceneByName(destinationSceneName);

        destinationStencilIndex = _key.destinationStencilInt;

        destinationLayerName = "St" + destinationStencilIndex.ToString();

        destinationLayerIndex = LayerMask.NameToLayer(destinationLayerName);
    }
    private void ChangeVisuals()
    {
        _mesh = _key.mesh;
        _mat = _key.material;
        if (_mesh != null) this.GetComponent<MeshFilter>().mesh = _mesh;
        if (_mat != null) this.GetComponent<MeshRenderer>().material = _mat;
    }


    private void Start()
    {
        //Camera must be found in start since all XR components are instantiated in GameManager.Awake()
        if (FindObjectOfType<Camera>().gameObject.CompareTag("MainCamera"))
            mainCamera = FindObjectOfType<Camera>().gameObject;
        else Debug.LogError("No Camera Found");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            if (!playerInRange)
            {
                if (elevator ==null)
                {
                    SpawnElevator();
                }
            }
        }
    }

    private void SpawnElevator()
    {
        Vector3 spawnPosition = this.transform.position - new Vector3(0, this.transform.localScale.y);

        //spawn the elevator in it's default rotation because rotating it from the get go is too complex
        elevator = Instantiate<GameObject>(_key.elevator, spawnPosition, Quaternion.identity);

        //adjusting the rotation of the elevator to look at player -not working 100% yet, must understand Quartenions- 
        elevator.transform.LookAt(mainCamera.transform.position);
        Quaternion idealRotation = new Quaternion(0, elevator.transform.rotation.y, 0, 1);
        elevator.transform.rotation = idealRotation;

        Actions.OnElevatorSpawned.Invoke(this, elevator);

        this.gameObject.SetActive(false);
    }
}
