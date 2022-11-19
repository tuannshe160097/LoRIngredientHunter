using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRIngredientHunter
{
    public class PassiveAbility_PreciseDrawCut : PassiveAbilityBase
    {
        public static string Desc = "When inflicting Bleed using combat pages, double the amount inflicted";

        public override int OnGiveKeywordBufByCard(BattleUnitBuf buf, int stack, BattleUnitModel target)
        {
            if (buf.bufType == KeywordBuf.Bleeding)
            {
                return stack;
            }

            return 0;
        }
    }

    public class PassiveAbility_ExpertButcher : PassiveAbilityBase
    {
        public static string Desc = "Combat pages with bleed will apply bleed regardless of the clash result. Enemies does not receive stagger damage from combat pages";

        private List<BattleUnitBuf> originalBufs;
        private List<BattleUnitBuf> originalReadyBufs;

        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                breakRate = -999,
            });
        }

        public override void OnStartParrying(BattlePlayingCardDataInUnitModel card)
        {
            originalBufs = card.target.bufListDetail.GetActivatedBufList();
            originalReadyBufs = card.target.bufListDetail.GetReadyBufList();
        }

        public override void OnDrawParrying(BattleDiceBehavior behavior)
        {
            ApplyBleedRegardless(behavior);
            ResetBufsToOriginal(behavior);
        }

        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            ApplyBleedRegardless(behavior);
            ResetBufsToOriginal(behavior);
        }

        private void ApplyBleedRegardless(BattleDiceBehavior behavior)
        {
            foreach (var ability in behavior.abilityList)
            {
                if (ability.Keywords.Contains("Bleeding_Keyword"))
                {
                    if (IsAttackDice(behavior))
                    {
                        ability.OnWinParrying();
                        ability.OnSucceedAttack();
                        ability.OnSucceedAttack(behavior.card.target);
                    }
                    else
                    {
                        ability.OnWinParryingDefense();
                    }
                }
            }
        }

        private bool IsAttackDice(BattleDiceBehavior behavior)
        {
            return behavior.Detail == LOR_DiceSystem.BehaviourDetail.Slash || behavior.Detail == LOR_DiceSystem.BehaviourDetail.Penetrate || behavior.Detail == LOR_DiceSystem.BehaviourDetail.Hit;
        }

        private void ResetBufsToOriginal(BattleDiceBehavior behavior)
        {
            /*var bufList = behavior.card.target.bufListDetail;
            var bleed = bufList.GetActivatedBuf(KeywordBuf.Bleeding);
            var bleedReady = bufList.GetReadyBuf(KeywordBuf.Bleeding);
            bufList.RemoveBufAll();

            foreach (var buf in originalBufs)
            {
                if (buf.bufType != KeywordBuf.Bleeding)
                {
                    bufList.AddBuf(buf);
                }
                else
                {
                    bufList.AddBuf(bleed);
                }
            }

            foreach (var buf in originalReadyBufs)
            {
                if (buf.bufType != KeywordBuf.Bleeding)
                {
                    bufList.AddBuf(buf);
                }
                else
                {
                    bufList.AddBuf(bleedReady);
                }
            }*/
        }
    }
}
