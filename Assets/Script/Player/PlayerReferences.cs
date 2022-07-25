/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Store away information and references from our Player Prefab
Dependencies: Must be attatched to Prefabs/XR/XR Origin
---------------------------------------------------------*/

using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    public PlayerScriptableObject _player;
    public GameObject stencilSphere;
    public Material stencilMaterial;
    public int stencilIndex;

    private string stencilID = "_StencilID";

    private void Awake()
    {
        _player.stencilSphere = stencilSphere;
        stencilMaterial = stencilSphere.GetComponent<Renderer>().material;

        stencilIndex = stencilMaterial.GetInt(stencilID);
    }

}
