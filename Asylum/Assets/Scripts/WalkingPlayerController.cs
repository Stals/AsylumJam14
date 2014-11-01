using UnityEngine;
using System.Collections;

public class WalkingPlayerController : MonoBehaviour {
	
	public KeyCode moveUp;
	public KeyCode moveDown;
	
	public KeyCode moveLeft;
	public KeyCode moveRight;

    public Vector2 speed = new Vector2(1.02f, 1.02f);

    Vector3 currentPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        currentPosition = this.transform.position;
        updateMovment();
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
        
        this.transform.position  =  new Vector3(currentPosition.x + v.x, currentPosition.y + v.y);

        /*
        transform.rotation = Quaternion.LookRotation( this.transform.position + v);
        */

        if ((v.x != 0) || (v.y != 0))
        {

            float rad = Mathf.Atan2(v.y, v.x);
            float degrees = (rad / Mathf.PI) * 180.0f;

            //Debug.Log(degrees);

            Vector3 angles = transform.eulerAngles;
            angles.z = degrees;

            transform.eulerAngles = angles;
        }

        //Quaternion q = transform.rotation;
       // q.z = degrees;

//        transform.rotation = q;

        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, degrees, transform.rotation.w);
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
