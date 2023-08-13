using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IGameModel
{
    Sprite PlayerOneCharacter { get; set; }
    Sprite PlayerTwoCharacter { get; set; }
    Dictionary<Vector2, GameVo> GamecellMap { get; set; }
    bool p1Turn { get; set; }
    bool p2Turn { get; set; }
    bool isGameDraw { get; set; }
}
