using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCellView : EventView
{
    public List<Image> gamecells = new List<Image>();


    public void OnClickGameCell(Image GameCell)
    {
        dispatcher.Dispatch(GameCellEvents.ClickCell, GameCell);
    }
}
