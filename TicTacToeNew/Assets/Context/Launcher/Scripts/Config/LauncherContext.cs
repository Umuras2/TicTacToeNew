using strange.examples.myfirstproject;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherContext : MVCSContext
{
	public LauncherContext(MonoBehaviour view) : base(view)
	{
	}

	public LauncherContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{
	}

	protected override void mapBindings()
	{
		commandBinder.Bind(ContextEvent.START).To<InitialStartLauncherCommand>().Once();
	}
}
