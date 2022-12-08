using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_LastSupper : PassiveAbilityBase
    {
        public static string Desc = "When an allie dies, recover 10% HP and Stagger Resist and gain 1 Hunter's Perseverance";

        private static int stack = 0;

        public override void OnWaveStart()
        {
            new BattleUnitBuf_HuntersPerseverance().AddTo(owner, stack);
        }

        public override void OnDieOtherUnit(BattleUnitModel unit)
        {
            if (unit.faction == owner.faction)
            {
                owner.RecoverHP(owner.MaxHp / 10);
                owner.breakDetail.RecoverBreak(owner.MaxBreakLife / 10);

                new BattleUnitBuf_HuntersPerseverance().AddTo(owner, 1);

                stack++;
            }
        }
    }
}
