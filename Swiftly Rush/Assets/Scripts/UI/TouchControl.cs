﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class TouchControl : MonoBehaviour {

    public void OnMouseUp()
    {
        if(Time.time > touchTime + TOUCH_MAX_TIME)
        {
            return;
        }

        fingerUp = Input.mousePosition;

        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeDown();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeUp();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeLeft();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeRight();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
            OnClick();
        }


    }

    private void OnSwipeLeft()
    {
        Debug.Log("Swipe left");

    }

    private void OnSwipeRight()
    {
        Debug.Log("Swipe right");
    }

    private void OnSwipeDown()
    {
        Debug.Log("Swipe down");
    }

    private void OnSwipeUp()
    {
        Debug.Log("Swipe up");
    }

    void OnClick()
    {
        Debug.Log("Click");
        LevelMgr.Current.OnClick();
    }

    Vector3 fingerDown;
    Vector3 fingerUp;
    float touchTime;
    const float TOUCH_MAX_TIME = 0.2f;
    public void OnMouseDown()
    {
        touchTime = Time.time;

        fingerDown = Input.mousePosition;
    }

    public float SWIPE_THRESHOLD = 20f;

    public UnityEvent clickEvent;
    public UnityEvent swipeLeft;
    public UnityEvent swipeRight;

    float verticalMove()
    {
        return Mathf.Abs(fingerUp.y - fingerDown.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerUp.x - fingerDown.x);
    }
}


