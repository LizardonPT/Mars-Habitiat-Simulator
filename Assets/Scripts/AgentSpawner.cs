using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject agentPrefab;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public int minAgents = 100;

    public void SpawnAgents(int totalAgents)
    {
        // garantir mínimo
        totalAgents = Mathf.Max(totalAgents, minAgents);

        int half = totalAgents / 2;

        // Spawn no ponto 1
        for (int i = 0; i < half; i++)
        {
            SpawnAtPoint(spawnPoint1);
        }

        // Spawn no ponto 2
        for (int i = half; i < totalAgents; i++)
        {
            SpawnAtPoint(spawnPoint2);
        }
    }

    void SpawnAtPoint(Transform spawnPoint)
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-2f, 2f),
            0,
            Random.Range(-2f, 2f)
        );

        Instantiate(agentPrefab, spawnPoint.position + randomOffset, Quaternion.identity);
    }
}
