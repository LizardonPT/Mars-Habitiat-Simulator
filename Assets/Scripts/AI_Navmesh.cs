using UnityEngine;
using UnityEngine.AI;

public class AI_Navmesh : MonoBehaviour
{
    public Transform[] destinations;   // pontos possíveis
    public float minWaitTime = 2f;
    public float maxWaitTime = 5f;

    private NavMeshAgent agent;
    private Transform currentTarget;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChooseNewDestination();
    }

    private void Update()
    {
        // Se chegou ao destino
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Evitar múltiplas chamadas
            if (!IsInvoking(nameof(WaitAndMove)))
            {
                float waitTime = Random.Range(minWaitTime, maxWaitTime);
                Invoke(nameof(WaitAndMove), waitTime);
            }
        }
    }

    void WaitAndMove()
    {
        ChooseNewDestination();
    }

    void ChooseNewDestination()
    {
        if (destinations.Length == 0) return;

        Transform newTarget;

        // garantir que é diferente do atual
        do
        {
            newTarget = destinations[Random.Range(0, destinations.Length)];
        }
        while (newTarget == currentTarget && destinations.Length > 1);

        currentTarget = newTarget;
        agent.SetDestination(currentTarget.position);
    }
}
