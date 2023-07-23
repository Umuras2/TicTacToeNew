using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfigMenuBootstrap : ContextView
{
    private void Awake()
    {
        context = new PlayerConfigMenuContext(this);
    }
}
