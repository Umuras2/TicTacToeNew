using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GameCellEvents
{
    ClickCell
}

public class GameCellMediator : EventMediator
{
    [Inject]
    public GameCellView view { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

    public override void OnRegister()
    {
        view.dispatcher.AddListener(GameCellEvents.ClickCell, OnClickCell);
    }

    private void OnClickCell(IEvent payload)
    {
        
    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(GameCellEvents.ClickCell, OnClickCell);
    }
}
