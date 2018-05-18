using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using MonsterLove.StateMachine;

enum PlayState
{
    Ready,
    Playing,
    Jumping,
    Turning,
    Dying
};
public class LevelMgr :MonoBehaviour
{
    

    public static LevelMgr Current;

    StateMachine<PlayState> _fsm;
    
    public void Init()
    {
        _fsm = StateMachine<PlayState>.Initialize(this, PlayState.Ready);
    }

    void Awke()
    {
        Current = this;
        Init();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Ready_Enter()
    {
        Debug.Log("Ready");
        _fsm.ChangeState(PlayState.Playing);
    }

    void Playing_Enter()
    {
        Debug.Log("Playing");
    }

    public void Touch()
    {
        Debug.Log("Touch");
    }

    public void SlideLeft()
    {
        Debug.Log("Left");
    }

    public void SlideRight()
    {
        Debug.Log("Right");
    }

    


}

