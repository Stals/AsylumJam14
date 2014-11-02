using UnityEngine;
using System.Collections;

public enum LevelState{
	Running,
	Ended
}

public class GameManager : MonoBehaviour {

    [SerializeField]
    public GameObject player;
	[SerializeField]
    public GameObject brother;

    [SerializeField]
    public GameObject activatableImagePrefab;

    [SerializeField]
    UIFollowTarget speechPanel;

    [SerializeField]
    TileContainer firstTile;

    UILabel speechLabel;

    [SerializeField]
    GameObject blackBorders;

    [SerializeField]
    GameObject letGoHint;

	//[SerializeField]
	//GameOverController gameOverController;
    
	CameraShake cameraShake;
   

	// Use this for initialization
	void Start () {
        speechLabel = speechPanel.gameObject.GetComponentInChildren<UILabel>();

		Game.Instance.init (this);
        StartCoroutine(startGame());

		//cameraShake = Camera.main.gameObject.AddComponent("CameraShake") as CameraShake;
		//currentLevelLabel.text = "Level: " + (Game.Instance.getCurrentLevelID () + 1).ToString();
		//currentLevelState = LevelState.Running;

        cameraShake = Camera.main.gameObject.AddComponent("CameraShake") as CameraShake;
	}

    public IEnumerator startGame() {
        yield return new WaitForSeconds(1f);
        firstTile.tileEntered();
    }
	
    void FixedUpdate()
    {
        if (Game.Instance.HorrorNight)
        {
            shake();
        }
    }

	// Update is called once per frame
	void Update () {
        // TODO if button pressed -change world

        //if (Input.GetMouseButtonDown(1))
        //{
        //    CreateDeletingLine();
        //}
	}

    public void Speak(string text, float duration, GameObject speaker)
    {
        Transform panelTarget = speaker.GetComponentInChildren<Transform>();
        speechPanel.target = speaker.transform;
        speechLabel.text = text;
    }

    public void setBordersVisible(bool v)
    {
        blackBorders.SetActive(v);
    }

    public void setNightStateHorror(bool isHorror)
    {
        Game.Instance.HorrorNight = isHorror;
        NightDependantBehavior.ChangeNight(isHorror);
    }

    public void setHintVisible(bool visible)
    {
        letGoHint.SetActive(visible);
    }

    public void shake()
    {
        cameraShake.Shake (0.05f, 0.02f);
    }
}
