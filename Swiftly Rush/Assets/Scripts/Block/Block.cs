using System;
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
        Generate();      

	}

    void Generate()
    {
        GameObject gb = null;
		for(int i = 0; i <20;i++)
        {
            for (int j =0; j<5;j++)
            {
                gb = Instantiate<GameObject>(_resMgr.Cube);
                gb.transform.parent = transform;
                gb.transform.localPosition= new Vector3(j * SIZE -1,-SIZE,i * SIZE);
            }
        }

        BlockMonitor blockMonitor = gb.AddComponent<BlockMonitor>();
        blockMonitor.RegisterBlock(this,_blockMgr);

    }
    BlockMgr _blockMgr;
    internal void RegesterBlockMgr(BlockMgr blockMgr)
    {
        _blockMgr = blockMgr;
    }
}
