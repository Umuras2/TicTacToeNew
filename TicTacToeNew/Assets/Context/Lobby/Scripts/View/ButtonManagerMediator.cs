using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ButtonManagerEvent
{
    Play,
    Exit
}

public class ButtonManagerMediator : EventMediator
{
    [Inject]
    public ButtonManagerView view { get; set; }
    public override void OnRegister()
    {
        view.dispatcher.AddListener(ButtonManagerEvent.Play, OnPlay);
        view.dispatcher.AddListener(ButtonManagerEvent.Exit, OnExit);
    }

    private void OnPlay()
    {
        SceneManager.LoadScene("PlayerConfigMenu");
    }

    private void OnExit()
    {
        Application.Quit();
    }


    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(ButtonManagerEvent.Play, OnPlay);
        view.dispatcher.RemoveListener(ButtonManagerEvent.Exit, OnExit);
    }
}
