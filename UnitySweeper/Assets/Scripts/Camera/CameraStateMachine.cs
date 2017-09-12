using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cameraBehaviours
{
    Stay,
    Follow,
    Idle
}

public class CameraStateMachine : MonoBehaviour {

    private readonly Dictionary<cameraBehaviours, CameraStates> cameraStates = new Dictionary<cameraBehaviours, CameraStates>();

    private CameraStates currentStates;

    private void Start()
    {
        addStates(cameraBehaviours.Stay, GetComponent<CameraStay>());
        addStates(cameraBehaviours.Follow, GetComponent<CameraFollow>());
        addStates(cameraBehaviours.Idle, GetComponent<CameraIdle>());

        setState(cameraBehaviours.Idle);
    }

    private void addStates(cameraBehaviours cameraBehaviour, CameraStates state)
    {
        cameraStates.Add(cameraBehaviour, state);
    }

    private void Updates()
    {
        if(currentStates != null)
        {
            currentStates.Reason();
            currentStates.Act();
        }
    }

    private void setState(cameraBehaviours cameraBehaviourID)
    {
        // if the state doesn't exist in the dictionary stop
        if (!cameraStates.ContainsKey(cameraBehaviourID))
            return;

        if (currentStates != null)
            currentStates.Leave();

        currentStates = cameraStates[cameraBehaviourID];
        currentStates.Enter();
    }
    
}
