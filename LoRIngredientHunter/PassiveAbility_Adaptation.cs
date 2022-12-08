using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_Adaptation : PassiveAbilityBase
    {
        public static string Desc = "Add special Combat Pages to hand depending on certain conditions";

        public override void OnRoundStart()
        {
/*            owner.personalEgoDetail.RemoveCard(01);
            owner.personalEgoDetail.RemoveCard(02);
            owner.personalEgoDetail.RemoveCard(03);

            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count > 0)
            {
                owner.personalEgoDetail.AddCard(01);
            }
            else if (owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_HuntersPerseverance)?.stack >= 5)
            {
                owner.personalEgoDetail.AddCard(02);
            } 
            else
            {
                owner.personalEgoDetail.AddCard(03);
            }*/
        }
    }
}
