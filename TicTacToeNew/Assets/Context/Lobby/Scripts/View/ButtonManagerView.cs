using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerView : EventView
{
    public void OnPlayButton()
    {
        dispatcher.Dispatch(ButtonManagerEvent.Play);
    }

    public void OnExitButton()
    {
        dispatcher.Dispatch(ButtonManagerEvent.Exit);
    }
}
