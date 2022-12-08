using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_VeilOfBlood : PassiveAbilityBase
    {
        public static string Desc = "At the start of the scene, gain a stack of Bloodveil for each character with 10 or more bleed";

        public override void OnRoundStart()
        {
            int stack = 0;
            foreach (var character in BattleObjectManager.instance.GetAliveList())
            {
                if (character.bufListDetail.GetActivatedBuf(KeywordBuf.Bleeding)?.stack >= 10)
                {
                    stack++;
                }
            }

            if (stack != 0)
            {
                new BattleUnitBuf_Bloodveil().AddTo(owner, stack);
            }
        }
    }
}
