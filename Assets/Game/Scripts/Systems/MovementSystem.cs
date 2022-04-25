using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using System.Threading.Tasks;



[RequireComponent(typeof(NavMeshAgent))]
public class MovementSystem : MonoBehaviour
{
    
    public static UnityEngine.AI.NavMeshAgent agent;
    Controls controls;
    private bool mouseButtonPressed;
    public static Vector3 mouseHitpoint;


    private void Awake()
    {
        controls = new Controls();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    private void Update()
    {
        if (controls.Gameplay.Move.IsPressed())
        {
            calculateMovement();
        }

    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }


    private void calculateMovement()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        RaycastHit hit;
        Ray ray;

        ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //InstantlyTurnPlayer(hit.point);
            mouseHitpoint = hit.point;
            agent.SetDestination(hit.point);
        }

    }

}



