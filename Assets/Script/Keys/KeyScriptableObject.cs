/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Store Information regarding the Key: its destination and visuals.
Dependencies: -
---------------------------------------------------------*/
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "KeyScriptableObject", menuName = "Custom/Key")]
public class KeyScriptableObject : ScriptableObject
{

    public string destinationSceneName;
    public int destinationStencilInt;
    public Mesh mesh;
    public Material material;
    public GameObject elevator;

}
