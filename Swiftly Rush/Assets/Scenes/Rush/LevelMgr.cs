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
    Dying
};
public class LevelMgr :MonoBehaviour
{
    const float MOVE_TIME = 0.2f;
    const float JUMP_TIME = 0.2f;

    int _way = 0;

    public static LevelMgr Current;

    Player _player; 

    StateMachine<PlayState> _fsm;
    UIMgr uiMgr;
    public void Init()
    {
        uiMgr = FindObjectOfType<UIMgr>();
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
        uiMgr.SetStateText("Get Ready!");
        //_fsm.ChangeState(PlayState.Playing);
    }

    void Playing_Enter()
    {
        Debug.Log("Playing");
        uiMgr.SetStateText("Playing");
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
        if (_fsm.State == PlayState.Playing && _way >-2)
        {
            _way--;
            _player.RunActions(new MTMoveBy(MOVE_TIME, -1 * _player.transform.right));
            
        }
    }

    public void SwipeRight()
    {
        if (_fsm.State == PlayState.Playing && _way <2)
        {
            _way++;
            _player.RunActions(new MTMoveBy(MOVE_TIME, _player.transform.right));
        }
    }

    public void OnClick()
    {
        if(_fsm.State == PlayState.Ready)
        {
            _fsm.ChangeState(PlayState.Playing);
        }
    }

    public void Jumping_Enter()
    {

        _player.RunActions(new MTRotateBy(0.1f, 0, 90, 0f), new MTCallFunc(ChangeToPlaying));
    }
   

    void ChangeToPlaying()
    {
        _fsm.ChangeState(PlayState.Playing);
    }
}

