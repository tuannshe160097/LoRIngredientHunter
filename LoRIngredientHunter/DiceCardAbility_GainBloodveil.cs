using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardAbility_GainBloodveil : DiceCardAbilityBase
    {
        public static string Desc = "[On hit] Gain 1 Bloodveil";

        public override void OnSucceedAttack()
        {
            new BattleUnitBuf_Bloodveil().AddTo(owner, 1);
        }
    }
}
