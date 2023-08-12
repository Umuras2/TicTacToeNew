using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    [Inject]
    public IPlayerModel playerModel { get; set; }

    public override void OnRegister()
    {
        view.dispatcher.AddListener(GameCellEvents.ClickCell, OnClickCell);

        FillGameCellMap();
    }

    private void OnClickCell(IEvent payload)
    {
        GamePanelView gamePanelView = GetComponentInParent<GamePanelView>();
        Image cell = payload.data as Image;
        if (cell.sprite == null)
        {
            if (gameModel.p1Turn)
            {
                cell.sprite = gameModel.PlayerOneCharacter;
                cell.raycastTarget = false;
                gameModel.p1Turn = false;
                gameModel.p2Turn = true;
                gamePanelView.playerOneTurnLabel.text = "Player's Turn: ";
                gamePanelView.playerTwoTurnLabel.text = "Player's Turn: " + playerModel.playerTwoName;
                gameModel.GamecellMap[cell.name].playerCharacter = playerModel.playerOneCrossOrCircle.ToUpper();
            }
            else if (gameModel.p2Turn)
            {
                cell.sprite = gameModel.PlayerTwoCharacter;
                cell.raycastTarget = false;
                gameModel.p1Turn = true;
                gameModel.p2Turn = false;
                gamePanelView.playerOneTurnLabel.text = "Player's Turn: " + playerModel.playerOneName;
                gamePanelView.playerTwoTurnLabel.text = "Player's Turn: ";
                gameModel.GamecellMap[cell.name].playerCharacter = playerModel.playerTwoCrossOrCircle.ToUpper();
            }
            
        }
    }

    //private void ControlGameFinish()
    //{
    //    foreach (GameVo gameVo in gameModel.GamecellMap.Values)
    //    {
            
    //    }
    //}

    private void FillGameCellMap()
    {
        gameModel.GamecellMap = new Dictionary<string, GameVo>();

        foreach (Image cell in view.gamecells)
        {
            string[] vectorValues = cell.name.Split(",");
            string valueX = vectorValues[0];
            string valueY = vectorValues[1];
            int x = int.Parse(valueX);
            int y = int.Parse(valueY);
            GameVo gameVo = new GameVo();
            gameModel.GamecellMap.Add(cell.gameObject.name, gameVo);
        }
    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(GameCellEvents.ClickCell, OnClickCell);
    }
}
