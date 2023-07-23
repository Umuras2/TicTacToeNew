using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStartLobbyCommand : EventCommand
{
    public override void Execute()
    {
        Debug.Log("Lobby");
    }
}
