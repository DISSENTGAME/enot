using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class emenim : MonoBehaviour
{
    public float RadiusAttack;
    public float RadiusWall;

    private bool isAttackPlayer;
    private bool isPointWall;

    private LayerMask layerPlayer;
    private LayerMask layerGround;

    private Transform player;
    private Vector3 pointWall;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<emenim>().transform;
        layerPlayer = LayerMask.GetMask("Player");
        layerGround = LayerMask.GetMask("Ground");
    }

    void FixedUpdate()
    {
        isAttackPlayer = Physics.CheckSphere(transform.position, RadiusAttack, layerPlayer);


        if (isAttackPlayer == true)
        {
            AttackPlayer();
        }
        else
        {
            if (isPointWall == true)
            {
                WalkPoint();
            }
            else
            {
                SetPointWalk();
            }
        }

    }

    private void AttackPlayer()
    {
        agent.SetDestination(player.position);
    }

    private void WalkPoint()
    {
        agent.SetDestination(pointWall);

        if (Vector3.Distance(transform.position, pointWall) < 1)
        {
            isPointWall = false;
        }
    }

    private void SetPointWalk()
    {
        float ranX = Random.Range(-RadiusWall, RadiusWall);
        float ranZ = Random.Range(-RadiusWall, RadiusWall);

        pointWall = new Vector3(transform.position.x + ranX, transform.position.y, transform.position.z + ranZ);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusAttack);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadiusWall);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pointWall, 1);

    }
}