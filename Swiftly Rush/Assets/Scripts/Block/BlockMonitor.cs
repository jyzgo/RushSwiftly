using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMonitor : MonoBehaviour {

    Block _block;
    BlockMgr _blockMgr;
    public void RegisterBlock(Block b,BlockMgr blockMgr)
    {
        _block = b;
        _blockMgr = blockMgr;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("invisible");
        Destroy(_block.gameObject,2f);
    }

    int seen = 0;
    private void OnBecameVisible()
    {
        Debug.Log("beseen");
        _blockMgr.GenBlock();

    }

}
