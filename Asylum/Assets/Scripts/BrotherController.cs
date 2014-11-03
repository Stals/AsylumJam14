﻿using UnityEngine;
using System.Collections;

public class BrotherController : MonoBehaviour {
   
    [SerializeField]
    public Transform teleportLocation;

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 0.05f;

    abstract public class State
    {
        public enum States
        {
            normal,
            runningFromSister,
            runningToFather
        }

        abstract public void Update(BrotherController me);
    }
    
    public class Normal : State
    {
        override public void Update(BrotherController me)
        {
            me.transform.LookAt(me.target.position);
            me.transform.Rotate(new Vector3(0,-90,0), Space.Self);//correcting the original rotation
        }
    }

    public class RunningFromSister : State
    {
        Vector3 target = new Vector3(36.64433f, 5f, 0);
        public float speed = 3f;

        override public void Update(BrotherController me)
        {
            if (Vector3.Distance(me.transform.position, target) > 1f)
            {//move if distance from target is greater than 1
                me.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            } else
            {
                //TODO teleport and change tile
                me.setState(new Normal());
                me.transform.position = me.teleportLocation.position;
            }

            me.transform.LookAt(target);
            me.transform.Rotate(new Vector3(0,-90,0), Space.Self);//correcting the original rotation
        }
    }

    public class RunningToFather : State
    {
        Vector3 target = new Vector3(75.65525f, 9.166532f, 0);
        public float speed = 3f;
        
        override public void Update(BrotherController me)
        {
            if (Vector3.Distance(me.transform.position, target) > 0.5f)
            {//move if distance from target is greater than 1
                me.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            } else
            {
                me.setState(new Normal());
            }
            
            me.transform.LookAt(target);
            me.transform.Rotate(new Vector3(0,-90,0), Space.Self);//correcting the original rotation
        }
    }

    State currentState;


    void Start () {
        setState(new Normal());
    }
    
    void Update(){
        //rotate to look at the player
        currentState.Update(this);

        //move towards the player
        //if (Vector3.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
        //    transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
        //}
    }

    public void setState(State state)
    {
        currentState = state;
    }


    /*
    public Transform target;
    public float speed;
    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }*/

}


