/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Checks if the player is close to the Elevator Spawning area
by making its Collider grow in size and detect a collision with the player.
Dependencies: Will be triggered by Actions.KeyActivated.
Note: Not yet Implemented.
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour
{
    [SerializeField]
    private float minSize;
    [SerializeField]
    private float maxSize;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float duration = 5f;


    private Vector3 maxSizeVector;
    private Vector3 minSizeVector;
    [SerializeField]
    private Vector3 sphereSizeVector;

    public bool playerInRange = true;

    private void Awake()
    {
        minSizeVector = new Vector3(minSize, minSize, minSize);
        maxSizeVector = new Vector3(maxSize, maxSize, maxSize);
        sphereSizeVector = minSizeVector;

        transform.localScale = sphereSizeVector;

    }

    public IEnumerator ActivateGrowth()
    {
        yield return StartCoroutine(GrowthLerp(minSizeVector, maxSizeVector, duration));
    }

    
    private IEnumerator GrowthLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0f;
        float rate = (1f / time) * speed;

        while (i < 1)
        {
            i += Time.deltaTime * rate;

            sphereSizeVector = Vector3.Lerp(a, b, time);
            sphereSizeVector = transform.localScale;
            Debug.Log("corutine runs");
            yield return playerInRange = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(GrowthLerp(minSizeVector, maxSizeVector, duration));
            playerInRange = true;
        }
    }
}
