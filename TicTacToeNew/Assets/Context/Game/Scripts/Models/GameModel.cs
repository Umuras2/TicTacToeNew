using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModel : IGameModel
{
    public Image PlayerOneCharacter { get; set; }
    public Image PlayerTwoCharacter { get; set; }

    public Dictionary<string, Vector2> GamecellMap { get; set; }
}
