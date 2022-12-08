using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class DiceCardAbility_RecycleOnce : DiceCardAbilityBase
    {
        private int count = 0;

        public override void AfterAction()
        {
            if (!owner.IsBreakLifeZero() && count < 1)
            {
                count++;
                ActivateBonusAttackDice();
            }
        }
    }
}
