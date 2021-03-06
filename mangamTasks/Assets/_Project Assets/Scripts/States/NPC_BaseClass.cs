using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

[RequireComponent(typeof(PlayerHasBomb))]
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
    public Transform _bombTest;


    Rigidbody rb;
    void Start()
    {
        BombSOposition.SOTrans_Value= _bombTest;
        Currentstate = nPCWithoutBombState;
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Currentstate.ToString());
        Currentstate = Currentstate.DoState(this);
        //Debug.Log("Target ")
        navMeshAgent.SetDestination(Target);
        rb.velocity = Vector3.zero;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(Target, new Vector3(.5f, .5f, .5f));
        Gizmos.DrawLine(transform.position,Target) ;
    }
}
