using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMgr : MonoBehaviour {

	// Use this for initialization


    int blockIndex = 0;
    void GenBlock()
    {
        var gb = new GameObject("block" + blockIndex);
        gb.AddComponent<Block>();
        blockIndex ++;
    }
	

}
