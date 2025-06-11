using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState : MonoBehaviour
{
    protected NPCController npc;

    public NpcState(NPCController npc)   //√ ±‚»≠
    {
        this.npc = npc;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
