﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWithBombState : INPState
{
    public INPState DoState(NPC_BaseClass npc)
    {
        return change(npc);
    }

    private INPState change(NPC_BaseClass npc)
    {
        if (!(npc.GetComponent<PlayerHasBomb>().HasBomb))
            return npc.nPCWithoutBombState;
        else
            return this;

    }
}
