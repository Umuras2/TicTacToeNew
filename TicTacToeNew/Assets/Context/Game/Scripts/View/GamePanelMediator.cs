using RSG;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public enum GamePanelEvent
{
    Reset
}

public class GamePanelMediator : EventMediator
{
    [Inject]
    public GamePanelView view { get; set; }

    [Inject]
    public IPlayerModel playerModel { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

    private List<string> playerCharacterList = new List<string>();

    private int index;

    


    public override void OnRegister()
    {
        view.dispatcher.AddListener(GamePanelEvent.Reset, OnReset);


        Load();
    }

    private void Load()
    {
        view.playerOneLabel.text = playerModel.playerOneName;
        view.playerTwoLabel.text = playerModel.playerTwoName;
        playerCharacterList.Add(playerModel.playerOneCrossOrCircle.ToUpper());
        playerCharacterList.Add(playerModel.playerTwoCrossOrCircle.ToUpper());
        Sprites();
        view.playerOneTurnLabel.text = "Player's Turn: " + playerModel.playerOneName;
        gameModel.p1Turn = true;
    }

    private IPromise CallSpriteAsset()
    {
        Promise promise = new Promise();
        
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(playerCharacterList[index++]);

        handle.Completed += asynchandle =>
        {
            if (asynchandle.Status == AsyncOperationStatus.Succeeded)
            {
                Sprite sprite = asynchandle.Result;
                int p = index - 1;
                if (p == 0)
                {
                    FillPlayerOneCharacter(sprite);
                }
                else
                {
                    FillPlayerTwoCharacter(sprite);
                }
               
                promise.Resolve();
            }
            else
            {
                promise.Reject(new Exception());
            }
        };
        

        return promise;
    }

    private void Sprites()
    {
        List <Func<IPromise>> list = new List<Func<IPromise>>();

        for (int i = 0; i < 2; i++)
        {
            list.Add(() => CallSpriteAsset().Then(() => Debug.Log("Tamamlandý")));
        }

        Promise.Sequence(list).Then(() =>
        {
            index = 0;
            Debug.Log("All Sprites loaded.");
        });
    }

    private void FillPlayerOneCharacter(Sprite sprite)
    {
        if (playerModel.playerOneCrossOrCircle == playerCharacterList[0])
        {
            view.playerOneCharacterImage.sprite = sprite;
            gameModel.PlayerOneCharacter = sprite;
        }
        else if (playerModel.playerOneCrossOrCircle == playerCharacterList[1])
        {
            view.playerOneCharacterImage.sprite = sprite;
            gameModel.PlayerOneCharacter = sprite;
        }
    }

    private void FillPlayerTwoCharacter(Sprite sprite)
    {
        if (playerModel.playerTwoCrossOrCircle == playerCharacterList[0])
        {
            view.playerTwoCharacterImage.sprite = sprite;
            gameModel.PlayerTwoCharacter = sprite;
        }
        else if (playerModel.playerTwoCrossOrCircle == playerCharacterList[1])
        {
            view.playerTwoCharacterImage.sprite = sprite;
            gameModel.PlayerTwoCharacter = sprite;
        }
    }

    private void OnReset()
    {

    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(GamePanelEvent.Reset, OnReset);
    }
}
