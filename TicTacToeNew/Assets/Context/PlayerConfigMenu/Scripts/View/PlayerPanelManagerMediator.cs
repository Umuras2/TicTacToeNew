using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PlayerPanelManagerEvent
{
    Check,
    Play,
    PlayerOneDetect,
    PlayerTwoDetect
}
public class PlayerPanelManagerMediator : EventMediator
{
    [Inject]
    public PlayerPanelManagerView view { get; set; }
    [Inject]
    public IPlayerModel playerModel { get; set; }

    private List<string> playerCharacterList = new List<string>();

    public override void OnRegister()
    {
        view.dispatcher.AddListener(PlayerPanelManagerEvent.Check, OnCheck);
        view.dispatcher.AddListener(PlayerPanelManagerEvent.Play, OnPlay);
        view.dispatcher.AddListener(PlayerPanelManagerEvent.PlayerOneDetect, OnPlayerOneCrossOrCircleButtonDetect);
        view.dispatcher.AddListener(PlayerPanelManagerEvent.PlayerTwoDetect, OnPlayerTwoCrossOrCircleButtonDetect);

        view.playButton.interactable = false;

        playerCharacterList.Add("X");
        playerCharacterList.Add("O");
    }

    private void OnCheck()
    {
        if (view.playerOneInputField.text == view.playerTwoInputField.text)
        {
            view.statusLabel.text = "You are not choose same name.";
            view.playButton.interactable = false;
            view.playerOneInputField.text = "";
            view.playerTwoInputField.text = "";
        }
        else if (string.IsNullOrEmpty(playerModel.playerOneCrossOrCircle) && string.IsNullOrEmpty(playerModel.playerTwoCrossOrCircle))
        {
            view.statusLabel.text = "You must choose X or O";
            view.playButton.interactable = false;
            view.playerOneInputField.text = "";
            view.playerTwoInputField.text = "";
        }
        else
        {
            view.statusLabel.text = "All conditions completed.";
            playerModel.playerOneName = view.playerOneInputField.text;
            playerModel.playerTwoName = view.playerTwoInputField.text;
            view.playButton.interactable = true;
            if (playerModel.playerOneCrossOrCircle == playerModel.playerTwoCrossOrCircle)
            {
                ChangeName();
            }
        }
    }

    private void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    private void ChangeName()
    {
        int playerOneRandom;
        int playerTwoRandom;
        do
        {
            playerOneRandom = Random.Range(0, 2);
            playerTwoRandom = Random.Range(0, 2);
        } while (playerOneRandom == playerTwoRandom);

        playerModel.playerOneCrossOrCircle = playerCharacterList[playerOneRandom];
        playerModel.playerTwoCrossOrCircle = playerCharacterList[playerTwoRandom];
        Debug.Log("Player 1 " + playerModel.playerOneCrossOrCircle + " Player 2 " + playerModel.playerTwoCrossOrCircle);
    }

    public void OnPlayerOneCrossOrCircleButtonDetect(IEvent evt)
    {
        playerModel.playerOneCrossOrCircle = evt.data.ToString();
    }

    public void OnPlayerTwoCrossOrCircleButtonDetect(IEvent evt)
    {
        playerModel.playerTwoCrossOrCircle = evt.data.ToString();
    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.Check, OnCheck);
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.Play, OnPlay);
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.PlayerOneDetect, OnPlayerOneCrossOrCircleButtonDetect);
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.PlayerTwoDetect, OnPlayerTwoCrossOrCircleButtonDetect);
    }
}
