/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Pivot Monobehaivor to Set-Up the information from 
PivotScriptableObject.
Dependencies: Needs a PivotScriptableObject assigned in the Inspector.
Note: this.GameObject must be an empty GO that parents all the 
geometry in the scene.
---------------------------------------------------------*/

using UnityEngine;

public class ScenePivot : MonoBehaviour
{
    public PivotScriptableObject _pivot;

    public string sceneName;
    private void Awake()
    {
        sceneName = _pivot.sceneName;
        this.gameObject.tag = _pivot.tag;
    }
}
