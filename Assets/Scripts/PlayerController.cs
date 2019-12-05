using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using ST.Movement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0,1)] float boostSpeed = 0.5f;
    [SerializeField] [Range(0,1)] float normalSpeed = 0.1f;
    [SerializeField] AudioClip boostSFX;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 0.1f;
    [SerializeField] bool mouseMovementOverride = false;

    [SerializeField] Vector2 target;
    [SerializeField] Vector2 autoTarget;

    Mover mover;

    //float speed = 0.1f;

    bool isBoosted = false;

    BackgroundScroller backgroundScroller;
    // Start is called before the first frame update
    void Start()
    {
        //target = GetTarget();
        backgroundScroller = FindObjectOfType<BackgroundScroller>();
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }





    private void HandleMovement()
    {
        if (mouseMovementOverride)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            target = AutoMovement();
        }
        
        mover.MoveTo(target, speed);
    }


    private Vector2 AutoMovement()
    {        
        if (autoTarget == null)
        {
            autoTarget = GetRandomWaypoint(waypoints);
        }
        if (PlayerIsWithinAutoTargetRange())
        {
            autoTarget = GetRandomWaypoint(waypoints);
        }       
        return autoTarget;
    }


    private bool PlayerIsWithinAutoTargetRange()
    {
        float distance = Vector2.Distance(autoTarget, transform.position);
        return distance < 0.2;
    }


    public void Boost()
    {
        if (isBoosted) { return; }
        isBoosted = true;
        AudioSource.PlayClipAtPoint(boostSFX, Camera.main.transform.position, 1f);
        StartCoroutine(BoostSequence());
    }


    private Vector2 GetRandomWaypoint(Transform[] waypoints)
    {
        int randInt = Random.Range(0, waypoints.Length);
        print(randInt);
        Vector2 randomWaypoint = new Vector2(waypoints[randInt].position.x, waypoints[randInt].position.y);
        return randomWaypoint;
    }


    IEnumerator BoostSequence()
    {     
        backgroundScroller.SetBackgroundScrollSpeed(boostSpeed);
        yield return new WaitForSeconds(1f);
        backgroundScroller.SetBackgroundScrollSpeed(normalSpeed);
        isBoosted = false;
    }

}
