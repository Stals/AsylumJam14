using UnityEngine;
using System.Collections;

public class WalkingPlayerController : MonoBehaviour {

    #region Classes
    abstract public class State
    {
        public static int loneliness = 120;
        
        abstract public void Update(WalkingPlayerController me);
        virtual public void TurnToAlone(WalkingPlayerController me)
        {}
        virtual public void TurnToWithBrother(WalkingPlayerController me)
        {}

    }
    
    public class WithBrother : State
    {
        override public void Update(WalkingPlayerController me)
        {
            if (Input.GetKeyDown(KeyCode.Tab)) 
            {
                TurnToAlone(me);
            }
        }

        override public void TurnToAlone(WalkingPlayerController me)
        {
            loneliness = 120;
            me.GetComponent<SpringJoint2D>().enabled = false;
            Game.Instance.getManager().setNightStateHorror(true);
            me.CurrentBrotherState = new Alone();
            Game.Instance.getManager().brother.GetComponent<Rigidbody2D>().isKinematic = true;
            me.changeLightOpacity(0.78f);
            Game.Instance.getManager().particlesHorror.SetActive(true);
            Game.Instance.getManager().particlesBlack.SetActive(false);
            
        }
    }
    
    public class Alone : State
    {
        override public void Update(WalkingPlayerController me)
        {

            //loneliness--;
            //if (loneliness < 0)
            //{
            //    me.Die();
            //    return;
            //}


            if (Vector3.Magnitude(me.transform.position - Game.Instance.getManager().brother.transform.position) < 1.0f)
            {
                Game.Instance.getManager().setHoldHintVisible(true);
                if (Input.GetKeyDown(KeyCode.Tab)) 
                {
                    TurnToWithBrother(me);
                    Game.Instance.getManager().setHoldHintVisible(false);
                }
            }else{
                Game.Instance.getManager().setHoldHintVisible(false);
            }
        }

        override public void TurnToWithBrother(WalkingPlayerController me)
        {

                me.GetComponent<SpringJoint2D>().enabled = true;
                Game.Instance.getManager().setNightStateHorror(false);
                me.CurrentBrotherState = new WithBrother();
                Game.Instance.getManager().brother.GetComponent<Rigidbody2D>().isKinematic = false;
                me.changeLightOpacity(0.5f);
                Game.Instance.getManager().particlesHorror.SetActive(false);
                Game.Instance.getManager().particlesBlack.SetActive(true);
            
        }
    
        
    }
    
    #endregion

	
	public KeyCode moveUp;
	public KeyCode moveDown;
	
	public KeyCode moveLeft;
	public KeyCode moveRight;

    public Vector2 speed = new Vector2(1.02f, 1.02f);
    public Vector3 lastV = new Vector3();

    Vector3 currentPosition;

    State currentBrotherState;

    public bool lookingAtFather = false;

    [SerializeField]
    SpriteRenderer lightCircleLight;

    public void changeLightOpacity(float opacity)
    {
        Color color = lightCircleLight.color;// renderer.material.color;
        color.a = opacity;
        lightCircleLight.color = color;
    }

    public State CurrentBrotherState
    {
        get {return currentBrotherState;}
        set {currentBrotherState = value;}
    }


	// Use this for initialization
	void Start () {
        currentBrotherState = new WithBrother();
	}
	
	// Update is called once per frame
	void Update () {
        if (Game.Instance.isHandsChangeEnabled())
        {
            currentBrotherState.Update(this);	
        }

        if (lookingAtFather)
        {
            Vector3 v = Game.Instance.getManager().father.transform.position - transform.position;
            turnTo(v);
        }
	}

    void FixedUpdate()
    {
        currentPosition = this.transform.position;
        if (Game.Instance.isControlsEnabled())
        {
            updateMovment();
        }
    }

    public TileContainer getCurrentTile()
    {
        return transform.parent.GetComponent<TileContainer>();
    }

    void updateMovment()
    {
//        PlayerContoller playerController = Game.Instance.getPlayerShip().GetComponent<PlayerContoller>();

        Vector3 v = new Vector3(0f, 0f);
        
        if (Input.GetKey (moveUp)) 
        {
            v.y += speed.y;
        }
        if (Input.GetKey (moveDown)) 
        {
            v.y -= speed.y;
        }
        if (Input.GetKey(moveLeft))
        {
            v.x -= speed.x;
        }
        if (Input.GetKey(moveRight))
        {
            v.x += speed.x;
        }

        lastV = v;
        
        this.transform.position  =  new Vector3(currentPosition.x + v.x, currentPosition.y + v.y);

        if (!lookingAtFather)
        {
            turnTo(v);
        }

    }

    void turnTo(Vector3 v)
    {
        if ((v.x != 0) || (v.y != 0))
        {
            
            float rad = Mathf.Atan2(v.y, v.x);
            float degrees = (rad / Mathf.PI) * 180.0f;
            
            //Debug.Log(degrees);
            
            Vector3 angles = transform.eulerAngles;
            angles.z = degrees;
            
            transform.eulerAngles = angles;
        }
    }

    public void Die()
    {
        Debug.LogError("DEATH!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }

    public void LetGoOfBrother()
    {
        currentBrotherState.TurnToAlone(this);
    }

    /*public void PointTowardsMovementDirection()
    {
        Quaternion targetRotation = Quaternion.LookRotation
            (playerShip.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        
        //float z = Mathf.Lerp(transform.rotation.z, targetRotation.z, Time.deltaTime * 5f);
        //float w = Mathf.Lerp(transform.rotation.w, targetRotation.w, Time.deltaTime * 5
        //transform.rotation = new Quaternion(0, 0,z , w);
        
        transform.rotation = new Quaternion(0, 0, targetRotation.z, targetRotation.w);

        //transform.rotation = LookAtTarget(  Matrix.CreateLookAt(Vector3.Zero, Movement, Vector3.Up);
        //                                  transform.rotation = Matrix.Transpose(transform.rotation);
    }*/
}
