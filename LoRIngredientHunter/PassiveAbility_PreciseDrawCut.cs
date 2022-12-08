using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_PreciseDrawCut : PassiveAbilityBase
    {
        public static string Desc = "When inflicting Bleed using Combat Pages, double the amount inflicted";

/*        public override int OnGiveKeywordBufByCard(BattleUnitBuf buf, int stack, BattleUnitModel target)
        {
            if (buf.bufType == KeywordBuf.Bleeding)
            {
                return stack;
            }

            return 0;
        }*/

        public override int GetMultiplierOnGiveKeywordBufByCard(BattleUnitBuf cardBuf, BattleUnitModel target)
        {
            return 2;
        }
    }
}
