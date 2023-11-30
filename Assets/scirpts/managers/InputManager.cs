using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    private static Camera cam;
    private static Vector3 _mousePos;
    
    public static Ray GetCameraRay()
    {
        return cam.ScreenPointToRay(_mousePos);
    }
    
    private static Controls _controls;
    private static player _player; // Reference to the player instance
    private static gunSwapping _gunSwap;

    public static void Init(player playerInstance)
    {
        cam = Camera.main;
        
        _player = playerInstance; // Store the player instance

        _controls = new Controls();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        _controls.game.movemoent.performed += ctx =>
        {
            _player.SetMoveDirection(ctx.ReadValue<Vector3>());
        };

        _controls.game.jump.started += woah =>
        {
            _player.Jump();
        };
        _controls.game.Look.performed += woah =>
        {
            _player.SetLookDirection(woah.ReadValue<Vector2>());
        };
        _controls.game.Shoot.performed += woah =>
        {
            _player.Shoot();
        };
        _controls.game.Reload.performed += woah =>
        {
            _player.Reload();
        };
        //guns
        _controls.game.gun1.performed += woah =>
        {
            _player.GunSwap1();
        };
        _controls.game.gun2.performed += woah =>
        {
            _player.GunSwap2();
        };
        _controls.game.gun3.performed += woah =>
        {
            _player.GunSwap3();
        };
        _controls.game.gun4.performed += woah =>
        {
            _player.GunSwap4();
        };

        _controls.perma.Enable();

        _controls.perma.MousePos.performed += ctx =>
        {
            _mousePos = ctx.ReadValue<Vector2>();
        };

    }
    
    
    public static void GameMode()
    {
        _controls.game.Enable(); //when in game mode the controls for game will be enabled and UI will be disabled
        _controls.UI.Disable();
    }



    public static void UImode()
    {
        _controls.game.Disable();
        _controls.UI.Enable();
    }
    
}
