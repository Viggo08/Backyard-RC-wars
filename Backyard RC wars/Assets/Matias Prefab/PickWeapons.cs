using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

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

    [Header("UI")]
    public GameObject pickWeaponMenu;

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

        Debug.Log("PLAYER JOINED");
        Debug.Log("PLAYER COUNT: " + playerCount);



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

        currentPickingPlayer = 1;

        player1Input.SwitchCurrentActionMap("UI");
        player2Input.SwitchCurrentActionMap("UI");

        StartCoroutine(ReselectButtonNextFrame());

        Debug.Log("Player 1 Pick a Weapon");
    }

    private IEnumerator ReselectButtonNextFrame()
    {
        yield return null;

        EventSystem.current.SetSelectedGameObject(null);

        yield return null;

        SelectFirstAvailableButton();
    }

    public void PickWeapon(int weaponIndex)
    {
        if (currentState != GameState.PickingWeapons)
            return;
        WeaponType selectedWeapon = (WeaponType)weaponIndex;

        if (player1Choices.Contains(selectedWeapon) ||
           player2Choices.Contains(selectedWeapon))
        {
            Debug.Log("Weapon already taken!");
            return;
        }


        if (currentPickingPlayer == 1)
        {
            player1Choices.Add(selectedWeapon);

            Debug.Log("Player 1 picked " + selectedWeapon);

            currentPickingPlayer = 2;

            Debug.Log("Player 2 Pick a Weapon");
        }



        else
        {
            player2Choices.Add(selectedWeapon);

            Debug.Log("Player 2 picked " + selectedWeapon);

            currentPickingPlayer = 1;

            Debug.Log("Player 1 Pick a Weapon");
        }

    
        DisableSelectedWeaponButton(selectedWeapon);

        totalPicks++;

        if (totalPicks >= 4)
        {
            StartGame();
            return;
        }

        StartCoroutine(ReselectButtonNextFrame());
    }



    private void StartGame()
    {
        pickWeaponMenu.SetActive(false);
        currentState = GameState.Playing;

        Debug.Log("GAME STARTED");



        foreach (WeaponType weapon in player1Choices)
        {
            player1Weapons.EnableWeapon(weapon);
        }


        foreach (WeaponType weapon in player2Choices)
        {
            player2Weapons.EnableWeapon(weapon);
        }

        player1Input.SwitchCurrentActionMap("Player");
        player2Input.SwitchCurrentActionMap("Player");
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


    private void SelectFirstAvailableButton()
    {
        Button[] buttons =
        {
        potatoButton,
        drillButton,
        stapleButton,
        waterButton
    };

        foreach (Button button in buttons)
        {
            if (button.interactable)
            {
                button.Select();

                Debug.Log("SELECTED: " + button.name);

                break;
            }
        }
    }
}