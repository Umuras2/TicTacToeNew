using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialStartLauncherCommand : EventCommand
{
    public override void Execute()
    {
        SceneManager.LoadScene("Lobby");
    }
}
