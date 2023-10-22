using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player2Movement : MonoBehaviour
{
    public Transform Player;
    [SerializeField]
    private Animator Animator;
    public float UpdateRate = 0.1f;
    private NavMeshAgent Agent;

    private const string Walk = "Walk";

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(FollowTarget());
    }

    private void Update()
    {
        Animator.SetBool(Walk, Agent.velocity.magnitude > 0.01f);
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);

        while (enabled)
        {
            Agent.SetDestination(Player.transform.position - (Player.transform.position - transform.position).normalized * 0.5f);
            yield return Wait;
        }
    }
}