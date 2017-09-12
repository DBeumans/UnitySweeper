using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameAvailableStates
{
    finish,
    won,
    pause,
    play
}

public class GameStateMachine : MonoBehaviour {

    private readonly Dictionary<GameAvailableStates, GameStates> gameStates = new Dictionary<GameAvailableStates, GameStates>();

    private GameStates currentState;

    private void Start()
    {
        addState(GameAvailableStates.play, GetComponent<GamePlay>());
        addState(GameAvailableStates.finish, GetComponent<GameFinish>());
        addState(GameAvailableStates.won, GetComponent<GameWon>());
        addState(GameAvailableStates.pause, GetComponent<GamePause> ());

    }

    private void addState(GameAvailableStates availableState, GameStates state)
    {
        gameStates.Add(availableState, state);
    }

    private void setState(GameAvailableStates availableStateID)
    {
        if (!gameStates.ContainsKey(availableStateID))
            return;

        if (currentState != null)
            currentState.Leave();

        currentState = gameStates[availableStateID];
        currentState.Enter();
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.Act();
            currentState.Reason();
        }
    }

}
