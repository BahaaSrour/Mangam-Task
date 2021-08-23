using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWithoutBombState : INPState
{
    public INPState DoState(NPC_BaseClass npc)
    {
        ChangeNewTarget(npc);
        return change(npc);
        
    }

    private INPState change(NPC_BaseClass npc)
    {
        if (npc.clicked == false)
            return npc.nPCWithBombState;
        else
            return this;

    }


    void ChangeNewTarget(NPC_BaseClass npc)
    {
        if (Vector3.SqrMagnitude(npc.Target - npc.transform.position)>2 && npc.navMeshAgent.hasPath)
            return  ;

        npc.Target =  NPC_BaseClass.RandomNavSphere(npc.BombSOposition.SOTrans_Value.position, npc.MaximumPointNPCmovesTo,1);
          
    }



}
