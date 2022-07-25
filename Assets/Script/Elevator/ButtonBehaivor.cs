/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Triggers the Animations of opening and closing elevator doors.
Dependencies: Needs the Doors GameObject from the Elevator Prefab
to be assigned from the Inspector.
---------------------------------------------------------*/
using UnityEngine;

public class ButtonBehaivor : MonoBehaviour
{
    [SerializeField]
    private GameObject _doors;
    private Animator _doorAnimator;

    private bool isOpen;

    private void Start()
    {
        _doorAnimator = _doors.GetComponent<Animator>();
        isOpen = _doorAnimator.GetBool("Open");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            isOpen = !isOpen;

            _doorAnimator.SetBool("Open", isOpen);
        }
        
    }

}
