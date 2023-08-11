using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IGameModel
{
    Image PlayerOneCharacter { get; set; }
    Image PlayerTwoCharacter { get; set; }
    Dictionary<string, Vector2> GamecellMap { get; set; }

}
