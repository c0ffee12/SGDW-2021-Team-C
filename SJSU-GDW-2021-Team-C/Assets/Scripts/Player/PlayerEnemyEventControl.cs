using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnemyEvents
{
    public class PlayerEnemyEventControl : MonoBehaviour
    {

        CatFSM fsm;

        public PlayerEnemyEventControl Initialize(CatFSM fsm)
        {
            this.fsm = fsm;
            return this;
        }

        public void PlayerTakeDamage(bool Direction)
        {
            (fsm.states["PlayerTakeDamageState"] as PlayerTakeDamageState).KnockbackLeft = Direction;
            fsm.SetState("PlayerTakeDamageState");
        }


    }
}
