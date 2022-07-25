/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Instantiates the GameManager ONCE at the beginning of the game.
Dependencies: Needs the GameManager Prefab assigned in the Inspector.
---------------------------------------------------------*/

using UnityEngine;

public class ManagerInstantiation : MonoBehaviour
{
    [SerializeField]
    GameObject gameManagerPrefab;

    private void Awake()
    {
        if (!FindObjectOfType<GameManager>())
        {
            Instantiate(gameManagerPrefab);
        }

        Destroy(this.gameObject);
    }
}
