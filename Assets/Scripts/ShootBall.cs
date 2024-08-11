using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ShootBall : NetworkBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform shootTransform;
    [SerializeField] private List<GameObject> spawnedBalls = new List<GameObject>();

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            ShootServerRpc();

        }
    }
    [ServerRpc]
    private void ShootServerRpc()
    {
        GameObject go = Instantiate(ball, shootTransform.position, shootTransform.rotation);
        spawnedBalls.Add(go);
        go.GetComponent<MoveBall>().parent = this;
        go.GetComponent<NetworkObject>().Spawn();
    }

    [ServerRpc(RequireOwnership = false)]

    public void DestroyServerRpc()
    {

        GameObject toDestroy = spawnedBalls[0];
        toDestroy.GetComponent<NetworkObject>().Despawn();
        spawnedBalls.Remove(toDestroy);
        Destroy(toDestroy);
    }    
}
