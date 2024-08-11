using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MoveBall : NetworkBehaviour
{
    public ShootBall parent;
    [SerializeField] private GameObject hitParticles;
    [SerializeField] private float shootForce;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        rb.velocity = rb.transform.forward * shootForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsOwner) return;
        //GameObject hitImpact = Instantiate(hitParticles, transform.position, Quaternion.identity);
        //hitImpact.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        //Destroy(gameObject);
        parent.DestroyServerRpc();
    }

}
