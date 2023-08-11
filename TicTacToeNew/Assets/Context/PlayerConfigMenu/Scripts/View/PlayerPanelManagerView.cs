using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelManagerView : EventView
{
    public TMP_InputField playerOneInputField;
    public TMP_InputField playerTwoInputField;

    public TMP_Text statusLabel;

    public Button checkButton;
    public Button playButton;

    public Button playerOneCrossButton;
    public Button playerOneCircleButton;

    public Button playerTwoCrossButton;
    public Button playerTwoCircleButton;

    public Image background;


    public void OnPlay()
    {
        dispatcher.Dispatch(PlayerPanelManagerEvent.Play);
    }

    public void OnCheck()
    {
        dispatcher.Dispatch(PlayerPanelManagerEvent.Check);
    }

    public void OnPlayerOneDetect(TextMeshProUGUI Text)
    {
        dispatcher.Dispatch(PlayerPanelManagerEvent.PlayerOneDetect, Text.text);
    }

    public void OnPlayerTwoDetect(TextMeshProUGUI Text)
    {
        dispatcher.Dispatch(PlayerPanelManagerEvent.PlayerTwoDetect, Text.text);
    }
}
