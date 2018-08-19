using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Destination : MonoBehaviour
{
    public NPC_Move npc;

    // on click, adjust npc target position
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                npc.SetDestination(hit.point);
            }
        }
    }
}
