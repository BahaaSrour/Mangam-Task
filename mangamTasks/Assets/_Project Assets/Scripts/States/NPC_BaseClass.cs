using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class NPC_BaseClass : MonoBehaviour
{
    public bool clicked = false;
    public NPCWithoutBombState nPCWithoutBombState = new NPCWithoutBombState();
    public NPCWithBombState nPCWithBombState = new NPCWithBombState();
    public INPState Currentstate;
    public  NavMeshAgent navMeshAgent;
    public Vector3 Target;

    public TransformSO BombSOposition;

    public float MaximumPointNPCmovesTo;
    public LayerMask LayerMask;
    void Start()
    {
        BombSOposition.SOTrans_Value= transform;
        Currentstate = nPCWithBombState;
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Currentstate = Currentstate.DoState(this);
        //Debug.Log("Target ")
        navMeshAgent.SetDestination(Target);
        Debug.Log(Currentstate.ToString());
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
