/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Invoke events relative to the state of an Animation.
Dependencies: Needs to be wired up to an Animation within an Animator:
    Animations/FakeElevator/FElevator/ClosingDoors
---------------------------------------------------------*/ 
using UnityEngine;

public class AnimationEvents : StateMachineBehaviour
{
    bool _open = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (stateInfo.normalizedTime >= 1 && _open)
        {
            Actions.OnDoorsClosed.Invoke(KeyChain.activeKey);
            _open = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
