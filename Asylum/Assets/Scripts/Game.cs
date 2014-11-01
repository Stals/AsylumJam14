using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game  {
	private static Game instance;
	private Game() {
	}
	public static Game Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new Game();
			}
			return instance;
		}
	}

	GameManager manager;


	public void init(GameManager _manager)
	{
		manager = _manager;
	}

	public GameManager getManager()
	{
		return manager;
	}
}