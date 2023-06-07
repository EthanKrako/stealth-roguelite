using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    private float waitTime = 1f;
    [SerializeField] private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (waitTime <= 0) {
            agent.SetDestination(target.position);
        } else {
            waitTime -= Time.deltaTime;
        }
    }
}
