using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        LevelMgr.Current.RegisterPlayer(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
