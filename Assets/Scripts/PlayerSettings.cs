using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using Unity.Collections;

public class PlayerSettings : NetworkBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private NetworkVariable<FixedString128Bytes> networkPlayerName = new NetworkVariable<FixedString128Bytes>(
        "Player: 0", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    public List<Color> colors = new List<Color>();

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        
            networkPlayerName.Value = "Player: " + (OwnerClientId + 1);
        

        playerName.text = networkPlayerName.Value.ToString();
        meshRenderer.material.color = colors[(int)OwnerClientId];
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!IsServer) return;

        if (collider.GetComponent<AutoDestroy>() && GetComponent<NetworkObject>().OwnerClientId != collider.GetComponent<NetworkObject>().OwnerClientId)
        {
            Debug.Log("collision");
            GetComponent<NetworkHealthState>().HealthPoint.Value -= 10;
        }
    }
}
