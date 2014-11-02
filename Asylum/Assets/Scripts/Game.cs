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
    bool controlsEnabled;
    bool handsChangeEnabled;
    bool reachedHandsAbility;
    bool isHorrorNight = false;

    public bool HorrorNight
    {
        get {return isHorrorNight;}
        set {isHorrorNight = value;}
    }


	public void init(GameManager _manager)
	{
		manager = _manager;
        controlsEnabled = true;
        handsChangeEnabled = true;
        reachedHandsAbility = true;
	}

    public void setControlsEnabled(bool e)
    {
        controlsEnabled = e;
    }

    public bool isControlsEnabled()
    {
        return controlsEnabled;
    }

    public void setReachedHandsAbility(bool e)
    {
        reachedHandsAbility = e;
    }

    public bool isHandsChangeEnabled()
    {
        if (reachedHandsAbility)
        {
            return handsChangeEnabled;
        } else
        {
            return false;
        }
    }

    public void setHandsChangeEnabled(bool e)
    {
        handsChangeEnabled = e;
    }

	public GameManager getManager()
	{
		return manager;
	}


}