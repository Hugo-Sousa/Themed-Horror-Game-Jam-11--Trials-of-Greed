using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class Mummy : MonoBehaviour
{

    public GameObject player;
    private Animator anim;
    private AIPath aiPath;
    private AIDestinationSetter targetStetter;

    public Light2D patrolLight;
    public Light2D chaseLight;

    public Transform[] patrolPoints;
    private int pastPatrol;
    
    public bool playerDetected;
    private Vision vision;
    
    private bool chase;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        aiPath = GetComponentInParent<AIPath>();
        targetStetter = GetComponentInParent<AIDestinationSetter>();
        vision = GetComponentInChildren<Vision>();

        pastPatrol = int.Parse(targetStetter.target.gameObject.name);
        GetComponent<AudioSource>().Play();
    }
    
    void Update()
    {
        anim.SetFloat("Horizontal", aiPath.desiredVelocity.x*10);
        anim.SetFloat("Vertical", aiPath.desiredVelocity.y*10);

        if ((playerDetected || vision.playerDetected) && !chase)
        {
            targetStetter.target = player.transform;
            chase = true;
            StartCoroutine(SpeedBoost());
        }
        
        if (aiPath.reachedDestination && !(playerDetected || vision.playerDetected))
        {
            targetStetter.target.position = PickRandomPoint();
            aiPath.SearchPath();
        }
    }
    
    Vector3 PickRandomPoint ()
    {
        int index = Random.Range(0, patrolPoints.Length);

        while (index == pastPatrol)
        {
            index = Random.Range(0, patrolPoints.Length);
        }
        
        Vector3 point = patrolPoints[index].position;
        pastPatrol = index;
        
        return point;
    }
    
    IEnumerator SpeedBoost()
    {
        patrolLight.gameObject.SetActive(false);
        chaseLight.gameObject.SetActive(true);
        
        while (playerDetected || vision.playerDetected)
        {
            aiPath.maxSpeed = 2;
            yield return new WaitForSeconds(2);
            aiPath.maxSpeed = 0.3f;
        }
        
        patrolLight.gameObject.SetActive(true);
        chaseLight.gameObject.SetActive(false);
        chase = false;
        aiPath.maxSpeed = 1f;
        targetStetter.target = patrolPoints[0];
        aiPath.SearchPath();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            playerDetected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            playerDetected = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6 )
        {
            player.GetComponent<PlayerMovement>().death = true;
        }
    }
}
