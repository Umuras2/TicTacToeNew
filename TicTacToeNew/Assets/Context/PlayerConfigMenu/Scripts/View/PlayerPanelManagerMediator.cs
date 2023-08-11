using RSG;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
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

    private Image playerOneCrossButtonImage;

    private Image playerTwoCrossButtonImage;

    private Image playerOneCircleButtonImage;

    private Image playerTwoCircleButtonImage;

    [SerializeField]
    private AssetReference prefabReferance;

    public override void OnRegister()
    {
        view.dispatcher.AddListener(PlayerPanelManagerEvent.Check, OnCheck);
        view.dispatcher.AddListener(PlayerPanelManagerEvent.Play, OnPlay);
        view.dispatcher.AddListener(PlayerPanelManagerEvent.PlayerOneDetect, OnPlayerOneCrossOrCircleButtonDetect);
        view.dispatcher.AddListener(PlayerPanelManagerEvent.PlayerTwoDetect, OnPlayerTwoCrossOrCircleButtonDetect);

        view.playButton.interactable = false;

        playerCharacterList.Add("X");
        playerCharacterList.Add("O");

        playerOneCrossButtonImage = view.playerOneCrossButton.gameObject.GetComponent<Image>();
        playerTwoCrossButtonImage = view.playerTwoCrossButton.gameObject.GetComponent<Image>();

        playerOneCircleButtonImage = view.playerOneCircleButton.gameObject.GetComponent<Image>();
        playerTwoCircleButtonImage = view.playerTwoCircleButton.gameObject.GetComponent<Image>();
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
        else if (string.IsNullOrEmpty(playerModel.playerOneCrossOrCircle) || string.IsNullOrEmpty(playerModel.playerTwoCrossOrCircle))
        {
            view.statusLabel.text = "You must choose X or O";
            view.playButton.interactable = false;
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
        RunCode();            
    }

    private void RunCode()
    {
        GetGamePanelPrefab().Then(() =>
        {
            gameObject.SetActive(false);
            view.background.gameObject.SetActive(false);
        });
    }

    private IPromise GetGamePanelPrefab()
    {
        Promise promise = new Promise();
        AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.InstantiateAsync("GamePanel", gameObject.transform.parent);

        asyncOperationHandle.Completed += handle =>
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                promise.Resolve();
            }
            else
            {
                promise.Reject(new Exception());
            }
        };

        return promise;
    }

    private void ChangeName()
    {
        int playerOneRandom;
        int playerTwoRandom;
        do
        {
            playerOneRandom = UnityEngine.Random.Range(0, 2);
            playerTwoRandom = UnityEngine.Random.Range(0, 2);
        } while (playerOneRandom == playerTwoRandom);

        playerModel.playerOneCrossOrCircle = playerCharacterList[playerOneRandom];
        playerModel.playerTwoCrossOrCircle = playerCharacterList[playerTwoRandom];
        Debug.Log("Player 1 " + playerModel.playerOneCrossOrCircle + " Player 2 " + playerModel.playerTwoCrossOrCircle);

        if (playerModel.playerOneCrossOrCircle == PlayerEvent.X.ToString())
        {
            playerOneCrossButtonImage.color = Color.red;
            playerOneCircleButtonImage.color = Color.white;
        }
        else
        {
            playerOneCrossButtonImage.color = Color.white;
            playerOneCircleButtonImage.color = Color.red;
        }

        if (playerModel.playerTwoCrossOrCircle == PlayerEvent.X.ToString())
        {
            playerTwoCrossButtonImage.color = Color.red;
            playerTwoCircleButtonImage.color = Color.white;
        }
        else
        {
            playerTwoCrossButtonImage.color = Color.white;
            playerTwoCircleButtonImage.color = Color.red;
        }
    }

    public void OnPlayerOneCrossOrCircleButtonDetect(IEvent evt)
    {
        playerModel.playerOneCrossOrCircle = evt.data.ToString();
        if (playerModel.playerOneCrossOrCircle == PlayerEvent.X.ToString())
        {
            if (playerOneCrossButtonImage.color != Color.red)
            {
                playerOneCrossButtonImage.color = Color.red;

                if (playerOneCircleButtonImage.color == Color.red)
                {
                    playerOneCircleButtonImage.color = Color.white;
                }
            }
            else
            {
                playerOneCrossButtonImage.color = Color.white;
                playerModel.playerOneCrossOrCircle = string.Empty;
            }
            
        }
        else if (playerModel.playerOneCrossOrCircle == PlayerEvent.O.ToString())
        {
            if (playerOneCircleButtonImage.color != Color.red)
            {
                playerOneCircleButtonImage.color = Color.red;

                if (playerOneCrossButtonImage.color == Color.red)
                {
                    playerOneCrossButtonImage.color = Color.white;
                }
            }
            else
            {
                playerOneCircleButtonImage.color = Color.white;
                playerModel.playerOneCrossOrCircle = string.Empty;
            }
        }
        
            
        
    }

    public void OnPlayerTwoCrossOrCircleButtonDetect(IEvent evt)
    {
        playerModel.playerTwoCrossOrCircle = evt.data.ToString();
        if (playerModel.playerTwoCrossOrCircle == PlayerEvent.X.ToString())
        {
            if (playerTwoCrossButtonImage.color != Color.red)
            {
                playerTwoCrossButtonImage.color = Color.red;

                if (playerTwoCircleButtonImage.color == Color.red)
                {
                    playerTwoCircleButtonImage.color = Color.white;
                }
            }
            else
            {
                playerTwoCrossButtonImage.color = Color.white;
                playerModel.playerTwoCrossOrCircle = string.Empty;
            }

        }
        else if (playerModel.playerTwoCrossOrCircle == PlayerEvent.O.ToString())
        {
            if (playerTwoCircleButtonImage.color != Color.red)
            {
                playerTwoCircleButtonImage.color = Color.red;

                if (playerTwoCrossButtonImage.color == Color.red)
                {
                    playerTwoCrossButtonImage.color = Color.white;
                }
            }
            else
            {
                playerTwoCircleButtonImage.color = Color.white;
                playerModel.playerTwoCrossOrCircle = string.Empty;
            }
        }
    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.Check, OnCheck);
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.Play, OnPlay);
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.PlayerOneDetect, OnPlayerOneCrossOrCircleButtonDetect);
        view.dispatcher.RemoveListener(PlayerPanelManagerEvent.PlayerTwoDetect, OnPlayerTwoCrossOrCircleButtonDetect);
    }
}
