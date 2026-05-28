using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickWeapons : MonoBehaviour
{
    public enum GameState
    {
        WaitingForPlayers,
        PickingWeapons,
        Playing
    }

    [Header("Game State")]
    public GameState currentState;

    [Header("Weapon Buttons")]
    public Button potatoButton;
    public Button drillButton;
    public Button stapleButton;
    public Button waterButton;

    [Header("First Selected Button")]
    public Button firstSelectedButton;

    private GameObject player1;
    private GameObject player2;
    private PlayerInput player1Input;
    private PlayerInput player2Input;
    private PlayerWeapons player1Weapons;
    private PlayerWeapons player2Weapons;
    private int playerCount = 0;



    private List<WeaponType> player1Choices = new List<WeaponType>();
    private List<WeaponType> player2Choices = new List<WeaponType>();

    private int currentPickingPlayer = 1;
    private int totalPicks = 0;



    private void Start()
    {
        currentState = GameState.WaitingForPlayers;

        Debug.Log("Waiting For Players...");
    }


    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerCount++;



        if (playerCount == 1)
        {
            player1 = playerInput.gameObject;

            player1Input = player1.GetComponent<PlayerInput>();

            player1Weapons = player1.GetComponent<PlayerWeapons>();

            Debug.Log("Player 1 Joined");
        }



        if (playerCount == 2)
        {
            player2 = playerInput.gameObject;

            player2Input = player2.GetComponent<PlayerInput>();

            player2Weapons = player2.GetComponent<PlayerWeapons>();

            Debug.Log("Player 2 Joined");

            StartWeaponPicking();
        }
    }


    private void StartWeaponPicking()
    {
        currentState = GameState.PickingWeapons;

    
        player1Input.SwitchCurrentActionMap("UI");
        player2Input.SwitchCurrentActionMap("UI");


        player1Input.ActivateInput();
        player2Input.DeactivateInput();

        currentPickingPlayer = 1;


        EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);
    }



    public void PickWeapon(int weaponIndex)
    {
        WeaponType selectedWeapon = (WeaponType)weaponIndex;


        if (player1Choices.Contains(selectedWeapon) ||
           player2Choices.Contains(selectedWeapon))
        {
       
            return;
        }


        if (currentPickingPlayer == 1)
        {
            player1Choices.Add(selectedWeapon);


            currentPickingPlayer = 2;

            player1Input.DeactivateInput();
            player2Input.ActivateInput();


        }


        else
        {
            player2Choices.Add(selectedWeapon);


            currentPickingPlayer = 1;

            player2Input.DeactivateInput();
            player1Input.ActivateInput();

        }

        totalPicks++;


        DisableSelectedWeaponButton(selectedWeapon);


        EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);

  

        if (totalPicks >= 4)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        currentState = GameState.Playing;


        foreach (WeaponType weapon in player1Choices)
        {
            player1Weapons.EnableWeapon(weapon);
        }


        foreach (WeaponType weapon in player2Choices)
        {
            player2Weapons.EnableWeapon(weapon);
        }


        player1Input.ActivateInput();
        player2Input.ActivateInput();
        player1Input.SwitchCurrentActionMap("Player");
        player2Input.SwitchCurrentActionMap("Player");

        Debug.Log("GAME STARTED");
    }


    private void DisableSelectedWeaponButton(WeaponType weapon)
    {
        switch (weapon)
        {
            case WeaponType.PotatoCannon:
                potatoButton.interactable = false;
                break;

            case WeaponType.Drill:
                drillButton.interactable = false;
                break;

            case WeaponType.StapleGun:
                stapleButton.interactable = false;
                break;

            case WeaponType.WaterMortar:
                waterButton.interactable = false;
                break;
        }
    }
}
