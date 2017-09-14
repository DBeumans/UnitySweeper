using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour {

    public enum GameAvailableStates
    {
        finish,
        won,
        play
    }

    private readonly Dictionary<GameAvailableStates, GameStates> gameStates = new Dictionary<GameAvailableStates, GameStates>();

    private GameStates currentState;

    private void Start()
    {
        addState(GameAvailableStates.play, GetComponent<GamePlay>());
        addState(GameAvailableStates.finish, GetComponent<GameOver>());
        addState(GameAvailableStates.won, GetComponent<GameWon>());

        SetState(GameAvailableStates.play);

    }

    private void addState(GameAvailableStates availableState, GameStates state)
    {
        gameStates.Add(availableState, state);
    }

    public void SetState(GameAvailableStates availableStateID)
    {
        if (!gameStates.ContainsKey(availableStateID))
            return;

        if (currentState != null)
            currentState.Leave();

        currentState = gameStates[availableStateID];
        currentState.Enter();
    }

    public GameStates GetCurrentState()
    {
        if (currentState != null)
            return currentState;

        return null;
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
