using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardAbility_HuntersPerseveranceCounter : DiceCardAbilityBase
    {
        public static string Desc = "[On clash lose] Recycle this dice";
        public override string[] Keywords => new string[] { "Bleeding_Keyword" };

        public override void BeforeRollDice()
        {
            var min = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_HuntersPerseverance)?.stack ?? 0;
            var max = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Bloodveil)?.stack ?? 0;

            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                min = min,
                max = max,
            });
        }

        public override void OnLoseParrying()
        {
            ActivateBonusAttackDice();
        }
    }
}
