using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardAbility_2Bleed1Fragile : DiceCardAbilityBase
    {
        public static string Desc = "[On hit] Inflict 2 Bleed and 1 Fragile next scene";

        public override string[] Keywords => new string[] { "Bleeding_Keyword", "Vulnerable_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 2, owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vulnerable, 1, owner);
        }
    }
}
