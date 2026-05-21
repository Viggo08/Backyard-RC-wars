using UnityEngine;
using UnityEngine.InputSystem;

public class PickWeapons : MonoBehaviour
{
    public GameState currentState;
    public PlayerInput playerInput;

  
    public enum GameState
    {
        PlayersExists,
        Pick1,
        Pick2,
        Pick3,
        Pick4,
        playing,
    }

    void Update()
    {
        HandleGameStates();
    }

    void HandleGameStates()
    {
        switch (currentState)
        {
            case GameState.PlayersExists:
                //If two players exists switch to Pick1
                break;

            case GameState.Pick1:
                //Player 1 is active and the picked weapon turns active for RC 1
                break;

            case GameState.Pick2:
                //player 1 is inactive and 2 gets active, picked weapon turns active for RC 2
                break;

            case GameState.Pick3:
                //Same as pick1
                break;

            case GameState.Pick4:
                //same as pick2 but also starts playing
                break;

            case GameState.playing:
                //Play the game, activate both RC
                break;
        }

    }

    void SwitchToMenuControls()
    {
        playerInput.SwitchCurrentActionMap("UI");
    }

    void SwitchToPlayingControls()
    {
        playerInput.SwitchCurrentActionMap("Player");
    }

    void CheckIfPlayerExists()
    {
        
    }

}
