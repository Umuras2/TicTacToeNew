using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherBootstrap : ContextView
{
    private void Awake()
    {
        context = new LauncherContext(this);
    }
}
