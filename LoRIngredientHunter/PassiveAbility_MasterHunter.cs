using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_MasterHunter : PassiveAbilityBase
    {
        public static string Desc = "Speed Dice Slot +2. At the start of the scene, gain 1 Bloodveil";

        public override void OnRoundStart()
        {
            new BattleUnitBuf_Bloodveil().AddTo(owner, 1);
        }

        public override int SpeedDiceNumAdder()
        {
            return 2;
        }
    }
}
