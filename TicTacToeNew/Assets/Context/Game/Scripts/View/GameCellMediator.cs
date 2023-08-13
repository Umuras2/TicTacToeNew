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

    private bool isHaveWinner;

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
                gameModel.GamecellMap[GetCellValue(cell)].playerCharacter = playerModel.playerOneCrossOrCircle.ToUpper();
                ControlGameFinish();
                if (!isHaveWinner)
                {
                    IsGameDrawControl();
                }
            }
            else if (gameModel.p2Turn)
            {
                cell.sprite = gameModel.PlayerTwoCharacter;
                cell.raycastTarget = false;
                gameModel.p1Turn = true;
                gameModel.p2Turn = false;
                gamePanelView.playerOneTurnLabel.text = "Player's Turn: " + playerModel.playerOneName;
                gamePanelView.playerTwoTurnLabel.text = "Player's Turn: ";
                gameModel.GamecellMap[GetCellValue(cell)].playerCharacter = playerModel.playerTwoCrossOrCircle.ToUpper();
                ControlGameFinish();
                if (!isHaveWinner)
                {
                    IsGameDrawControl();
                }
                
            }
            
        }
    }


    private void ControlGameFinish()
    {
        //1.satýr
        if (gameModel.GamecellMap[new Vector2(0,0)].playerCharacter == gameModel.GamecellMap[new Vector2(0,1)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(0, 2)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
        //1.sütun
        if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(1, 0)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(2, 0)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
        //2.satýr
        if (gameModel.GamecellMap[new Vector2(1, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(1, 1)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(1, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(1, 2)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(1, 0)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
        //2.sütun
        if (gameModel.GamecellMap[new Vector2(0, 1)].playerCharacter == gameModel.GamecellMap[new Vector2(1, 1)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(0, 1)].playerCharacter == gameModel.GamecellMap[new Vector2(2, 1)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(0, 1)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
        //3.satýr
        if (gameModel.GamecellMap[new Vector2(2, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(2, 1)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(2, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(2, 2)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(2, 0)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
        //3.sütun
        if (gameModel.GamecellMap[new Vector2(0, 2)].playerCharacter == gameModel.GamecellMap[new Vector2(1, 2)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(0, 2)].playerCharacter == gameModel.GamecellMap[new Vector2(2, 2)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(0, 2)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
        //Çapraz
        if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(1, 1)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == gameModel.GamecellMap[new Vector2(2, 2)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(0, 0)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
        //Çapraz
        if (gameModel.GamecellMap[new Vector2(0, 2)].playerCharacter == gameModel.GamecellMap[new Vector2(1, 1)].playerCharacter)
        {
            if (gameModel.GamecellMap[new Vector2(0, 2)].playerCharacter == gameModel.GamecellMap[new Vector2(2, 0)].playerCharacter)
            {
                if (gameModel.GamecellMap[new Vector2(0, 2)].playerCharacter == playerModel.playerOneCrossOrCircle)
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerOneName);
                }
                else
                {
                    isHaveWinner = true;
                    DisableClicklableFunctionCells(playerModel.playerTwoName);
                }
            }
        }
    }

    private void FillGameCellMap()
    {
        gameModel.GamecellMap = new Dictionary<Vector2, GameVo>();
        int counter = 0;
        foreach (Image cell in view.gamecells)
        {
            string[] vectorValues = cell.name.Split(",");
            string valueX = vectorValues[0];
            string valueY = vectorValues[1];
            int x = int.Parse(valueX);
            int y = int.Parse(valueY);
            GameVo gameVo = new GameVo();
            gameVo.playerCharacter = "m" + counter;
            counter++;
            gameModel.GamecellMap.Add(new Vector2(x,y), gameVo);
        }
    }

    private Vector2 GetCellValue(Image cell)
    {
        string[] vectorValues = cell.name.Split(",");
        string valueX = vectorValues[0];
        string valueY = vectorValues[1];
        int x = int.Parse(valueX);
        int y = int.Parse(valueY);
        return new Vector2(x, y);
    }

    private void DisableClicklableFunctionCells(string winnerName)
    {
        foreach (Image cells in view.gamecells)
        {
            cells.gameObject.GetComponent<Button>().interactable = false;
            cells.raycastTarget = false;
        }
        dispatcher.Dispatch(GamePanelEvent.GameFinished, winnerName);
    }

    private void IsGameDrawControl()
    {
        
        foreach (GameVo gameVo in gameModel.GamecellMap.Values)
        {
            if (gameVo.playerCharacter == "X" || gameVo.playerCharacter == "O")
            {
                gameModel.isGameDraw = true;
                continue;
            }
            else
            {
                gameModel.isGameDraw = false;
                break;
            }
        }

        if (gameModel.isGameDraw)
        {
            dispatcher.Dispatch(GamePanelEvent.GameFinished, "Game is DRAWWWW!!!!!!");
        }
    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(GameCellEvents.ClickCell, OnClickCell);
    }
}
