using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_Hunter : PassiveAbilityBase
    {
        public static string Desc = "Speed Dice Slot +1. Gain an additional Speed die at Emotion Level 3. At the start of the scene, gain 1 Bloodveil";

        public override void OnRoundStart()
        {
            new BattleUnitBuf_Bloodveil().AddTo(owner, 1);
        }

        public override int SpeedDiceNumAdder()
        {
            BattleUnitModel battleUnitModel = owner;
            if (battleUnitModel != null && battleUnitModel.emotionDetail?.EmotionLevel >= 3)
            {
                return 2;
            }

            return 1;
        }
    }
}
