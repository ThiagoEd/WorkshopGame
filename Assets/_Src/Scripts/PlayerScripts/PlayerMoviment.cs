using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Playermovement : MonoBehaviour // é um script que age dentro do jogo
{
    [Header("Layers")]
    public LayerMask groundLayer;

    private NavMeshAgent nav;

    private void Start() // Start is called before the first frame update
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update() // Update is called once per frame
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            ManageMovement();
        }
    }

    private void ManageMovement() // Corrigido para estar fora do Update
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("HITANDO CHAO"); // "CHAO" pode ser mantido, se preferir
                nav.SetDestination(hit.point);
            }
        }
    }
}
