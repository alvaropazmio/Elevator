/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Store information regarding the pivot and the scene.
Dependencies: -
---------------------------------------------------------*/

using UnityEngine;

[CreateAssetMenu(fileName = "PivotScriptableObject", menuName = "Custom/Scene Pivot")]
public class PivotScriptableObject : ScriptableObject
{
    public string sceneName;
    public string tag = "ScenePivot";
}
