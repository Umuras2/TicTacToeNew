using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModel : IGameModel
{
    public Sprite PlayerOneCharacter { get; set; }
    public Sprite PlayerTwoCharacter { get; set; }

    public bool p1Turn { get; set; }

    public bool p2Turn { get; set; }

    public Dictionary<Vector2, GameVo> GamecellMap { get; set; }

    public bool isGameDraw { get; set; }
}
