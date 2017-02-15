using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using System;

public class InputMapper : MonoBehaviour {
    private InputDevice[] deviceMappings = new InputDevice[4];
    private int[] characterMappings = new int[4] { -1, -1, -1, -1};

    private static InputMapper _instance;

    public static InputMapper Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InputMapper>();
            }

            if (_instance == null)
            {
                GameObject obj = new GameObject("InputMapper");
                _instance = obj.AddComponent<InputMapper>();
            }

            return _instance;
        }
    }

    private void Start()
    {
        InputManager.OnDeviceDetached += OnDeviceDetached;
    }

    public bool IsDeviceMapped(InputDevice device)
    {
        for (int i = 0; i < deviceMappings.Length; i++)
        {
            if (deviceMappings[i] == device)
            {
                return true;
            }
        }

        return false;
    }

    public int GetDevicePlayer(InputDevice device)
    {
        for (int i = 0; i < deviceMappings.Length; i++)
        {
            if (deviceMappings[i] == device)
            {
                return i;
            }
        }

        return -1;
    }

    public void MapDevice(int playerID, InputDevice device)
    {
        if (playerID >= 0 && playerID < deviceMappings.Length)
        {
            deviceMappings[playerID] = device;
        }
    }

    public InputDevice GetPlayerDevice(int playerID)
    {
        if (playerID >= 0 && playerID < deviceMappings.Length)
        {
            return deviceMappings[playerID];
        }

        return null;
    }

    public int GetFirstAvailablePlayer()
    {
        for (int i = 0; i < deviceMappings.Length; i++)
        {
            if (deviceMappings[i] == null)
            {
                return i;
            }
        }

        return -1;
    }

    public void SetPlayerCharacter(int playerID, int character)
    {
        if (playerID >= 0 && playerID < characterMappings.Length)
        {
            characterMappings[playerID] = character;
        }
    }

    public int GetPlayerCharacter(int playerID)
    {
        if (playerID >= 0 && playerID < characterMappings.Length)
        {
            return characterMappings[playerID];
        }

        return -1;
    }

    public bool IsCharacterTaken(int character)
    {
        for (int i = 0; i < characterMappings.Length; i++)
        {
            if (characterMappings[i] == -1)
            {
                return true;
            }
        }

        return false;
    }

    public void ClearPlayerCharacter(int playerID)
    {
        if (playerID >= 0 && playerID < characterMappings.Length)
        {
            characterMappings[playerID] = -1;
        }
    }

    private void OnDeviceDetached(InputDevice device)
    {
        for (int i = 0; i < deviceMappings.Length; i++)
        {
            if (deviceMappings[i] == device)
            {
                deviceMappings[i] = null;
            }
        }
    }
}
