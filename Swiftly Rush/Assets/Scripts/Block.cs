using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    ResMgr _resMgr;
    const float SIZE = 0.5f;
    private void Awake()
    {
        _resMgr = FindObjectOfType<ResMgr>();
    }
    // Use this for initialization
    void Start () {
        
		for(int i = 0; i <20;i++)
        {
            for (int j =0; j<5;j++)
            {
                var gb = Instantiate<GameObject>(_resMgr.Cube);
                gb.transform.parent = transform;
                gb.transform.position = new Vector3(j * SIZE -1,-SIZE,i * SIZE);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
