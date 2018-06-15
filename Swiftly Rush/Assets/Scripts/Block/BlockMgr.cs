using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMgr : MonoBehaviour {

    // Use this for initialization
    private void Start()
    {
        GenBlock();
       
    }

    int blockIndex = 0;
    public void GenBlock()
    {
  
        var gb = new GameObject("block" + blockIndex);
        Block block = gb.AddComponent<Block>();
        block.RegesterBlockMgr(this);
        block.transform.position = new Vector3(0, 0, 10 * blockIndex);
        blockIndex ++;
    }
	

}
