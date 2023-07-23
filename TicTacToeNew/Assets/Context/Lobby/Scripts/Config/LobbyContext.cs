using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyContext : MVCSContext
{
	public LobbyContext(MonoBehaviour view) : base(view)
	{
	}

	public LobbyContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{
	}

	protected override void mapBindings()
	{
		mediationBinder.Bind<ButtonManagerView>().To<ButtonManagerMediator>();


		commandBinder.Bind(ContextEvent.START).To<InitStartLobbyCommand>().Once();
	}
}
