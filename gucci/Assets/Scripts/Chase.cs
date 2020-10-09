using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    NavMeshAgent nm;
    public GameObject Player;



    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        nm.SetDestination(Player.transform.position);
    }
}