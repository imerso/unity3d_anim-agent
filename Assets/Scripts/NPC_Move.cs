//
// Moves the npc to a clicked location
// using path-finding and root-motion animator
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC_Move : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    int walk_id;


    void Start()
    {
        // cache info
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        anim = GetComponent<Animator>();
        walk_id = Animator.StringToHash("walk");        // faster than using strings
    }


    void Update()
    {
        // get a gross speed for the agent,
        // and if it is above a threshold,
        // switch to walk animation.
        Vector3 delta = agent.nextPosition - transform.position;
        delta.y = 0;
        float speed = delta.magnitude;

        // if above threshold, walk;
        // else, stop.
        anim.SetBool(walk_id, (speed > 0.75f));

        // this is a known trick to make agent work with root-motion;
        // it adjusts the agent when it becomes too far from the root-motion position.
        if (speed > agent.radius)
            agent.nextPosition = transform.position + 0.9f * delta;
    }


    void OnAnimatorMove()
    {
        // manually set animator root-motion,
        // making sure that it also follows agent desired position height
        Vector3 position = anim.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
    }


    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
