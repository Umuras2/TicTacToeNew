using RSG;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
                if (sprite.name == "X")
                {
                    view.playerOneCharacterImage.sprite = sprite;
                    gameModel.PlayerOneCharacter.sprite = sprite;
                }
                else
                {
                    view.playerTwoCharacterImage.sprite = sprite;
                    gameModel.PlayerTwoCharacter.sprite = sprite;
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
            list.Add(() => CallSpriteAsset().Then(() => Debug.Log("Tamamlandı")));
        }

        Promise.Sequence(list).Then(() =>
        {
            Debug.Log("All Sprites loaded.");
        });
    }

    private void OnReset()
    {

    }

    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(GamePanelEvent.Reset, OnReset);
    }
}
