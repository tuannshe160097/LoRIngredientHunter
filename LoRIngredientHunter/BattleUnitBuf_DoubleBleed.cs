using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class BattleUnitBuf_DoubleBleed : BattleUnitBuf
    {
        protected override string keywordId => "DoubleBleed";
        protected override string keywordIconId => "DoubleBleed";
        public override BufPositiveType positiveType => BufPositiveType.Positive;

        public override int OnGiveKeywordBufByCard(BattleUnitBuf buf, int stack, BattleUnitModel target)
        {
            if (buf.bufType == KeywordBuf.Bleeding)
            {
                return stack;
            }

            return 0;
        }
    }
}
