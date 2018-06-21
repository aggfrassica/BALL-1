﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private bool tap,swipeRight, swipeLeft;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;
   private void Update()
    {
        tap = swipeLeft = swipeRight = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion
        #region Mobile Inputs
        
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase==TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;

            }else if (Input.touches[0].phase == TouchPhase.Ended ||
                     Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }

        }
        #endregion
        //distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length>0)
            {
                swipeDelta = Input.touches[0].position - startTouch;

            }
            else if (Input.GetMouseButtonDown(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            }

        }

        //Move
        if (swipeDelta.magnitude >125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) >Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
                

            }
            Reset();

        }


    }


    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;


    }
    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeLeft{ get { return swipeLeft; } }



   
}
