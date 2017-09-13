using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour {

    public enum GameAvailableStates
    {
        finish,
        won,
        pause,
        play
    }

    private readonly Dictionary<GameAvailableStates, GameStates> gameStates = new Dictionary<GameAvailableStates, GameStates>();

    private GameStates currentState;

    private void Start()
    {
        addState(GameAvailableStates.play, GetComponent<GamePlay>());
        addState(GameAvailableStates.finish, GetComponent<GameOver>());
        addState(GameAvailableStates.won, GetComponent<GameWon>());
        addState(GameAvailableStates.pause, GetComponent<GamePause> ());

        setState(GameAvailableStates.play);

    }

    private void addState(GameAvailableStates availableState, GameStates state)
    {
        gameStates.Add(availableState, state);
    }

    public void setState(GameAvailableStates availableStateID)
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
