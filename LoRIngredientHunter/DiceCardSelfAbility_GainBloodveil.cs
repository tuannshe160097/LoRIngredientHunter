using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardSelfAbility_GainBloodveilIfBleed : DiceCardSelfAbilityBase
    {
        public static string Desc = "If target has Bleed, gain 1 Bloodveil";
        public override void OnUseCard()
        {
            if (card.target.bufListDetail.HasBuf<BattleUnitBuf_bleeding>())
            {
                new BattleUnitBuf_Bloodveil().AddTo(owner, 1);
            }
        }
    }
}
