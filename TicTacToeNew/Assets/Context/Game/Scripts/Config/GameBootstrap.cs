using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : ContextView
{
    private void Awake()
    {
        context = new GameContext(this);
    }
}
