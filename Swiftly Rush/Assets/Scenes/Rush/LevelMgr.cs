using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using MonsterLove.StateMachine;
using MTUnity.Actions;

enum PlayState
{
    Ready,
    Playing,
    Jumping,
    ToRight,
    ToLeft,
    Dying
};
public class LevelMgr :MonoBehaviour
{
    const float MOVE_TIME = 0.2f;
    const float JUMP_TIME = 0.2f;

    public static LevelMgr Current;

    Player _player; 

    StateMachine<PlayState> _fsm;
    
    public void Init()
    {
        
        _fsm = StateMachine<PlayState>.Initialize(this, PlayState.Ready);
    }

    void Awake()
    {
        Current = this;
        Init();
    }

    public void RegisterPlayer(Player p)
    {
        _player = p;
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
        //_fsm.ChangeState(PlayState.Playing);
    }

    void Playing_Enter()
    {
        Debug.Log("Playing");
    }

    const float SPEED = 0.05f;
    void Playing_Update()
    {
        _player.transform.position += _player.transform.forward * SPEED;
    }

    public void Touch()
    {
        Debug.Log("Touch");
    }

    
    public void SwipeLeft()
    {
        if (_fsm.State == PlayState.Playing)
        {
            _fsm.ChangeState(PlayState.ToLeft);
        }
    }

    public void SwipeRight()
    {
        if (_fsm.State == PlayState.Playing)
        {
            _fsm.ChangeState(PlayState.ToRight);
        }
    }

    public void OnClick()
    {
        if(_fsm.State == PlayState.Ready)
        {
            _fsm.ChangeState(PlayState.Playing);
        }else if(_fsm.State == PlayState.Playing)
        {
            Debug.Log("Jump");
            _fsm.ChangeState(PlayState.Jumping);
        }
    }

    public void Jumping_Enter()
    {

        _player.RunActions(new MTRotateBy(0.1f, 0, 90, 0f), new MTCallFunc(ChangeToPlaying));
    }
    public void ToLeft_Enter()
    {
        Debug.Log("Left");
        _player.RunActions(new MTMoveBy(MOVE_TIME, -1 * _player.transform.right), new MTCallFunc(ChangeToPlaying));
    }


    public void ToRight_Enter()
    {
        Debug.Log("Right");
        _player.RunActions(new MTMoveBy(MOVE_TIME, _player.transform.right), new MTCallFunc(ChangeToPlaying));
    }

    void ChangeToPlaying()
    {
        _fsm.ChangeState(PlayState.Playing);
    }
}

