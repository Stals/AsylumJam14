using UnityEngine;
using System.Collections;

public class BrotherController : MonoBehaviour {
   
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 0.05f;
    
    void Start () {
        
    }
    
    void Update(){
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation

        //move towards the player
        //if (Vector3.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
        //    transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
        //}
    }

    /*
    public Transform target;
    public float speed;
    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }*/

}


