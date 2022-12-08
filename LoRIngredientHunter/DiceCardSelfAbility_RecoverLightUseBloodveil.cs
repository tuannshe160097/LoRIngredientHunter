using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardSelfAbility_RecoverLightUseBloodveil : DiceCardSelfAbilityBase
    {
        public static string Desc = "Recover 1 Light. Consume 1 Bloodveil, draw one Page and recover an additional Light";

        public override string[] Keywords => new string[] { "DrawCard_Keyword", "Energy_Keyword" };

        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPointByCard(1);

            if (BattleUnitBuf_Bloodveil.CanSubstract(owner, 1))
            {
                new BattleUnitBuf_Bloodveil().AddTo(owner, -1);
                owner.allyCardDetail.DrawCards(1);
                owner.cardSlotDetail.RecoverPlayPointByCard(1);
            }
        }
    }
}
