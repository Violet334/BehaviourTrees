using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public LayerMask raycastLayers;
    public Camera cam;

    public Transform spawn;
    public Transform sandwich;

    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is touching the ground, go to where the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Linecast(transform.position, Vector3.down, raycastLayers))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                Clicked(ray);
            }
            else
            {
                //otherwise, set the destination to spawn point
                navAgent.SetDestination(spawn.position);
            }
        }

        //if the player is near the sandwich, steal sandwich
        if (Vector3.Distance(transform.position, sandwich.position) < 1f){
            text.text = "sandwich acquired";
        }
    }
    void Clicked(Ray ray)
    {
        //code to set the player pathing
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, raycastLayers))
        {
            navAgent.SetDestination(hit.point);
        }
    }
}
