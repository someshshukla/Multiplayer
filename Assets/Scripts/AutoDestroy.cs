using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AutoDestroy : NetworkBehaviour
{

    public float delayBeforeDestroy = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayBeforeDestroy);
    }

    
}
