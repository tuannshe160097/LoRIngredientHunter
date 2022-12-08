using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class BattleUnitBuf_HuntersPerseverance : BattleUnitBuf
    {
        protected override string keywordId => "HuntersPerseverance";
        protected override string keywordIconId => "HuntersPerseverance";

        public override BufPositiveType positiveType => BufPositiveType.Positive;

        public override void OnRoundStart()
        {
            _owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, stack);
            new BattleUnitBuf_Bloodveil().AddTo(_owner, stack);
        }

        public override void OnDie()
        {
            _owner.RecoverHP(((int)(_owner.MaxHp * 0.2 * stack)));
            _owner.breakDetail.RecoverBreak(((int)(_owner.MaxBreakLife * 0.2 * stack)));
        }
    }
}
