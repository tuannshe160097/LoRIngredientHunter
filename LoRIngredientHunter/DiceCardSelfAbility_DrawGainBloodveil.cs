using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardSelfAbility_DrawGainBloodveil : DiceCardSelfAbilityBase
    {
        public static string Desc = "Draw 1 Page. If target has Bleed, gain 1 Bloodveil";

        public override string[] Keywords => new string[] { "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);

            if (card.target.bufListDetail.HasBuf<BattleUnitBuf_bleeding>())
            {
                new BattleUnitBuf_Bloodveil().AddTo(owner, 1);
            }
        }
    }
}
