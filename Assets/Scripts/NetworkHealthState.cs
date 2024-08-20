using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class NetworkHealthState : NetworkBehaviour
{
    //[HideInInspector]
    public NetworkVariable<int> HealthPoint = new NetworkVariable<int>();

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        HealthPoint.Value = 100;
    }

}
 