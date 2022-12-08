using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardAbility_IncreaseMaxByBloodveil : DiceCardAbilityBase
    {
        public static string Desc = "Increase the maximum roll of this Dice by the amount of Bloodveil";

        public override void BeforeRollDice()
        {
            var max = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Bloodveil)?.stack ?? 0;

            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                max = max,
            });
        }
    }
}
