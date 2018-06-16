using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    // Use this for initialization
    void Start () {
        LevelMgr.Current.RegisterPlayer(this);
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);
    }
}
