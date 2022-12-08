using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardSelfAbility_BloodveilRecycleDice : DiceCardSelfAbilityBase
    {
        public static string Desc = "Draw 1 Page. Consume one Bloodveil to recycle every dice on this page once";

        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);

            if (BattleUnitBuf_Bloodveil.CanSubstract(owner, 1))
            {
                new BattleUnitBuf_Bloodveil().AddTo(owner, -1);

                foreach (var behavior in card.GetDiceBehaviorList())
                {
                    behavior.AddAbility(new DiceCardAbility_RecycleOnce());
                }
            }
        }
    }
}
