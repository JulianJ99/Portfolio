using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    public AudioSource source;
    public AudioClip clip;
    public float volume = 0.5f;

    UnityEngine.AI.NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;


    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if(health.IsDead()){
            enabled = false;
            navMeshAgent.enabled = false;
            source.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked){
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

    }

    private void EngageTarget(){
            if(!GetComponent<AudioSource>().isPlaying){
                source.PlayOneShot(source.clip, volume);
             }
             
             FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance){
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance){
            AttackTarget();
           
        }
    }

    public void OnDamageTaken(){
        isProvoked = true;
    }

    private void ChaseTarget(){
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget(){
        GetComponent<Animator>().SetBool("attack", true);
        //Debug.Log("Look out, " + target.name + "! There's a " + name);
    }

    private void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected(){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
