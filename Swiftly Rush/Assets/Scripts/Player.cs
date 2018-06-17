using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    // Use this for initialization
    Rigidbody _playerRigidbody;
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

            Debug.DrawRay(transform.position,Vector3.forward,Color.yellow);
    }

    public void SetMoveDirection(Vector3 vec)
    {

    }

    Vector3 _direction = Vector3.forward;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
       // Debug.Log("Collision " + collision.gameObject.name);
        //Ray MyRay = ObjectHit.position - ObjectFalling.position;

        //this will declare a variable which will store information about the object hit
        RaycastHit MyRayHit;
        if(Physics.Raycast(transform.position,Vector3.forward,out MyRayHit,0.5f))
        {
            if (MyRayHit.collider.gameObject == collision.gameObject)
            {
                Debug.Log("hit");
                Debug.DrawRay(transform.position, Vector3.forward, Color.red, 5f);
                LevelMgr.Current.ToLose();
            }
        }

        //this is the actual raycast
        //raycast(MyRay, out MyRayHit);

        ////this will get the normal of the point hit, if you dont understand what a normal is 
        ////wikipedia is your friend, its a simple idea, its a line which is tangent to a plane

        //vector3 MyNormal = MyRayHit.normal;

        ////this will convert that normal from being relative to global axis to relative to an
        ////objects local axis

        //MyNormal = MyRayHit.transform.transformdirection(MyNormal);

        ////this next line will compare the normal hit to the normals of each plane to find the 
        ////side hit

        //if (MyNormal == MyRayHit.transform.up)
        //{
        //    //you hit the top plane, act accordingly
        //}
        ////important note the use of the '-' sign this inverts the direction, -up == down. Down doesn't exist as a stored direction, you invert up to get it. 

        //if (MyNormal == -MyRayHit.transform.up)
        //{
        //    //you hit the bottom plane act accordingly
        //}
        //if (MyNormal == MyRayHit.transform.right)
        //{
        //    //hit right
        //}
        ////note the '-' sign converting right to left
        //if (MyNormal == -MyRayHit.transform.right)
        //{
        //    //hit left
        //}
    }

    internal void Jump()
    {
        _playerRigidbody.AddForce(Vector3.up * 500f);
    }
}
