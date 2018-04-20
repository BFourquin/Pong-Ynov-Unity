using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.red;
    }


    // Update is called once per frame

    void Update()
    {
        if (!isLocalPlayer)
            return;

        var y = Input.GetAxis("Vertical") * 0.1f;
        transform.Translate(0, y, 0);
    }
}
