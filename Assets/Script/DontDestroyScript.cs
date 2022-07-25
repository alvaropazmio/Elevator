/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: this.GameObject is not destroyed on Load.
Dependencies: Needs GameManager to add this Component to 
target Game Objects.
Note: There is a bug where this will only work if there is
already a DontDestroyScript in the Target Game Object.
---------------------------------------------------------*/

using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
    }

    private void OnDisable()
    {
        Destroy(this);
    }
}
