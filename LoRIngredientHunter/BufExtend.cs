using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    internal static class BufExtend
    {
        public static void AddTo(this BattleUnitBuf unitBuf, BattleUnitModel character, int stack)
        {
            if (stack == 0) return;

            var buf = character.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x.GetType() == unitBuf.GetType());

            if (buf == null)
            {
                unitBuf.stack = 0;
                buf = unitBuf;
                character.bufListDetail.AddBuf(buf);
            }

            buf.stack += stack;
            if (buf.stack <= 0)
            {
                buf.Destroy();

                return;
            }

            buf.OnAddBuf(stack);
        }
    }
}
