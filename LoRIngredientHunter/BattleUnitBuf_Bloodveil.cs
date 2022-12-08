using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class BattleUnitBuf_Bloodveil : BattleUnitBuf
    {
        protected override string keywordId => "Bloodveil";

        protected override string keywordIconId => "Bloodveil";

        public override BufPositiveType positiveType => BufPositiveType.Positive;

        public static bool CanSubstract(BattleUnitModel character, int stack)
        {
            var buf = character.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Bloodveil);

            if (buf == null || buf.stack < stack) return false;

            return true;
        }

        public override void OnAddBuf(int addedStack)
        {
            int num = 10;

            if (stack > num)
            {
                stack = num;
            }
        }

        public override StatBonus GetStatBonus()
        {
            return new StatBonus
            {
                dmgAdder = -stack,
                breakAdder = -stack,
            };
        }

        public override void OnRoundEnd()
        {
            if (_owner.passiveDetail.HasPassive<PassiveAbility_PrimalHunger>())
            {
                _owner.RecoverHP(stack*2);
                _owner.breakDetail.RecoverBreak(stack * 2);
            }
            else
            {
                _owner.RecoverHP(stack);
                _owner.breakDetail.RecoverBreak(stack);
            }

            Destroy();
        }
    }
}
