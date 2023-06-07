using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        agent.SetDestination(target.position);
    }
}
