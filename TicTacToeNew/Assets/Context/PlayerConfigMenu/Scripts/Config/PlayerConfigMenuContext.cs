using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfigMenuContext : MVCSContext
{
	public PlayerConfigMenuContext(MonoBehaviour view) : base(view)
	{
	}

	public PlayerConfigMenuContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{
	}

	protected override void mapBindings()
	{

		injectionBinder.Bind<IPlayerModel>().To<PlayerModel>().ToSingleton();
		injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();

		mediationBinder.Bind<PlayerPanelManagerView>().To<PlayerPanelManagerMediator>();
		mediationBinder.Bind<GameCellView>().To<GameCellMediator>();
		mediationBinder.Bind<GamePanelView>().To<GamePanelMediator>();
	}
}
