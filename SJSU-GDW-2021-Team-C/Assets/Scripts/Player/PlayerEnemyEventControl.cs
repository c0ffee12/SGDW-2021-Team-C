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
        private float InvulnTime = 5f;
        public float InvulnDuration { get; private set; } = 3f;


        public void FixedUpdate()
        {
            if(InvulnTime <= InvulnDuration)
                InvulnTime += Time.deltaTime;
        }

        public PlayerEnemyEventControl Initialize(CatFSM fsm)
        {
            this.fsm = fsm;
            return this;
        }

        public void PlayerTakeDamage(bool Direction)
        {
            fsm.curState.TakeDamage(Direction);
            InvulnTime = 0f;
        }

        public bool PlayerInvulnerable()
        {
            if(InvulnTime < InvulnDuration)
                return true;

            return false;
        }

        public bool PlayerCanDealDamage()
        {
            if(fsm.curState is PlayerTakeDamageState)
                return false;

            return true;
        }

    }
}
