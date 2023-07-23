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

    public GameObject playerOneCrossButton;
    public GameObject playerOneCircleButton;

    public GameObject playerTwoCrossButton;
    public GameObject playerTwoCircleButton;

}
