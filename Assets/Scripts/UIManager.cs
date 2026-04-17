using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public AgentSpawner spawner;

    public GameObject uiPanel;

    public void OnSpawnButton()
    {
        int value;

        if (int.TryParse(inputField.text, out value))
        {
            if (value >= 100)
            {
                spawner.SpawnAgents(value);

                uiPanel.SetActive(false);
            }
            else
            {
                Debug.Log("Minimum 100 agents!");
            }
        }
        else
        {
            Debug.Log("Value not accepted!");
        }
    }
}
