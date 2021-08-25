using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWithBombState : INPState
{
    public INPState DoState(NPC_BaseClass npc)
    {
        npc.BombSOposition.SOTrans_Value = npc.transform;
        GetNearestTarget(npc);
        return change(npc);
    }

    private INPState change(NPC_BaseClass npc)
    {
        if (!(npc.GetComponent<PlayerHasBomb>().HasBomb))
            return npc.nPCWithoutBombState;
        else
            return this;

    }

    void GetNearestTarget(NPC_BaseClass npc)
    {
        float minDistance = float.MaxValue;
        float x;
        for (int i = 0; i < AllPlayers.players.Count; i++)
        {
            if ( npc.gameObject == AllPlayers.players[i].gameObject) continue;

            if ((x = Vector3.SqrMagnitude(AllPlayers.players[i].transform.position - npc.transform.position)) < minDistance)
            {
                minDistance = x;
                npc.Target = AllPlayers.players[i].transform.position;
            }
        }
    }
}
