using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBootstrap : ContextView
{
    private void Awake()
    {
        context = new LobbyContext(this);
    }
}
