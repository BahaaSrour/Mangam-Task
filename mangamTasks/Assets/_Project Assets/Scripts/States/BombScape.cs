using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScape : INPState
{
    public INPState DoState(NPC_BaseClass npc)
    {
       return  change(npc);
    }

    private INPState change(NPC_BaseClass npc)
    {
        if (npc.clicked == false)
            return npc.nPCWithBombState;
        else
            return this;
       
    }
}
