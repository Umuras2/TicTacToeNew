using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class GamePanelView : EventView
{
    public TMP_Text playerOneLabel;
    public TMP_Text playerTwoLabel;

    public Image playerOneCharacterImage;
    public Image playerTwoCharacterImage;

    public TMP_Text playerOneTurnLabel;
    public TMP_Text playerTwoTurnLabel;

    public void OnReset()
    {
        dispatcher.Dispatch(GamePanelEvent.Reset);
    }
}
