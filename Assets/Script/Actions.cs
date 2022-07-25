/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Project: Travel n Transit (Elevator)
Purpose: Hosts Actions that will be Triggered from several Scripts.
Dependencies: -
---------------------------------------------------------*/
using UnityEngine;
using System;

public static class Actions
{

    public static Action<Key,GameObject> OnElevatorSpawned;
        /*  Invokers:
         *      Key.SpawnElevator()
         *  Triggers:
         *      ElevatorBehaivour.SetupElevator()
         *      GameManager.AddActiveKey()
         *      GameManager.LoadScene()
         */  
    public static Action<PlayerReferences> OnPlayerEntered;
        /*  Invokers:
         *      ElevatorBehaivour.OnTriggerEnter(Player)
         *  Triggers:
         *      ElevatorBehaivor.PlayerEnters()
         */
    public static Action<Key> OnDoorsClosed;
        /*  Invokers:
         *      AnimationEvents.OnStateUpdate()
         *  Triggers:
         *      ElevatorBehaivor.DestroyElevator()
         *      GameManager.UnloadScene()
         */
    //public static Action<Key> KeyActivated; 
}
