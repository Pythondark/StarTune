using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0,1)] float boostSpeed = 0.5f;
    [SerializeField] [Range(0,1)] float normalSpeed = 0.1f;
    [SerializeField] AudioClip boostSFX;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 0.1f;

    Vector2 target;

    //float speed = 0.1f;

    bool isBoosted = false;

    BackgroundScroller backgroundScroller;
    // Start is called before the first frame update
    void Start()
    {
        target = GetTarget();
        backgroundScroller = FindObjectOfType<BackgroundScroller>();
    }

    private Vector2 GetTarget()
    {
        return new Vector2(waypoints[0].position.x, waypoints[0].position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    public void Boost()
    {
        if (isBoosted) { return; }
        isBoosted = true;
        AudioSource.PlayClipAtPoint(boostSFX, Camera.main.transform.position, 1f);
        StartCoroutine(BoostSequence());
    }


    IEnumerator BoostSequence()
    {     
        backgroundScroller.SetBackgroundScrollSpeed(boostSpeed);
        yield return new WaitForSeconds(1f);
        backgroundScroller.SetBackgroundScrollSpeed(normalSpeed);
        isBoosted = false;
    }

}
