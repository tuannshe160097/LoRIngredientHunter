using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardSelfAbility_UseBloodveilDoubleBleed : DiceCardSelfAbilityBase
    {
        public static string Desc = "Consume 1 Bloodveil, double the amount of Bleed inflicted using this page";

        public override void OnUseCard()
        {
            if (BattleUnitBuf_Bloodveil.CanSubstract(owner, 1))
            {
                new BattleUnitBuf_Bloodveil().AddTo(owner, -1);
                new BattleUnitBuf_DoubleBleed().AddTo(owner, 1);
            }
        }

        public override void OnEndBattle()
        {
            new BattleUnitBuf_DoubleBleed().AddTo(owner, -1);
        }
    }
}
