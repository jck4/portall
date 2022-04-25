using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{

public NavMeshAgent agent;
public Transform player;
public LayerMask whatIsGround, Player;


public float timeBetweenAttacks;
public bool alreadyAttacked;
public bool playerInSightRange;
public bool playerInAttackRange;
public float sightRange, attackRange;

private void Update(){
    playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

    if (!playerInSightRange && !playerInAttackRange) Idle();
    if (playerInSightRange && !playerInAttackRange) ChasePlayer();
    if (playerInSightRange && playerInAttackRange) AttackPlayer();

}

void Awake(){
    player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    agent = GetComponent<NavMeshAgent>();
} 

void Idle(){
    
}

void ChasePlayer(){
        agent.SetDestination(player.position);
}


void AttackPlayer(){
    agent.SetDestination(transform.position);
    //transform.LookAt(player);

    if (!alreadyAttacked){
        alreadyAttacked = true;
    }

}

void ResetAttack(){

}

}