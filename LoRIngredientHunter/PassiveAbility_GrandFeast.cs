using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_GrandFeast : PassiveAbilityBase
    {
        public static string Desc = "Whenever this character recovers HP, recover half the amount to all allies";

        public override void OnRecoverHp(int amount)
        {
            foreach (var ally in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                if (ally != owner)
                {
                    ally.RecoverHP(amount / 2);
                }
            }
        }
    }
}
