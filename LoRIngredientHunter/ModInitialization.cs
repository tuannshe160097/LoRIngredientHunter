using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;
using LOR_DiceSystem;
using LOR_XML;

namespace LoRIngredientHunter
{
    public class ModInitialization : ModInitializer
    {
        /*public override void OnInitializeMod()
        {

        }*/

        public override void OnInitializeMod()
        {
            base.OnInitializeMod();

            var dict = typeof(BattleEffectTextsXmlList).GetField("_dictionary", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(BattleEffectTextsXmlList.Instance) as Dictionary<string, BattleEffectText>;

            dict["Bloodveil"] = new BattleEffectText()
            {
                ID = "Bloodveil",
                Name = "Bloodveil",
                Desc = "For this scene, receive {0} less damage and stagger damage from attacks. Recover {0} HP and Stagger Resist at the end of the scene"
            };

            dict["HuntersPerseverance"] = new BattleEffectText()
            {
                ID = "HuntersPerseverance",
                Name = "Hunter's Perseverance",
                Desc = "Gain {0} Haste and Bloodveil at the start of the scene. Gain a [Hunter's Perseverance] - [Bloodveil] counter dice. When receiving a lethal attack, recover 20% Hp and Stagger Resist for each stack of Hunter's Perseverance"
            };

            Harmony harmony = new Harmony("LOR.XML_");
            MethodInfo method = typeof(ModInitialization).GetMethod("BookModel_SetXmlInfo_Post");
            harmony.Patch(typeof(BookModel).GetMethod("SetXmlInfo", AccessTools.all), null, new HarmonyMethod(method), null, null, null);
            Init = true;
            path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            PreLoadBufIcons();
        }

        public static void BookModel_SetXmlInfo_Post(BookModel __instance, BookXmlInfo ____classInfo, ref List<DiceCardXmlInfo> ____onlyCards)
        {
            if (__instance.BookId.packageId == packageId)
            {
                foreach (int id in ____classInfo.EquipEffect.OnlyCard)
                {
                    DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(new LorId(packageId, id), false);
                    ____onlyCards.Add(cardItem);
                }
            }
        }

        public const string packageId = "IngredientHunters";

        public static void PreLoadBufIcons()
        {
            foreach (var baseGameIcon in Resources.LoadAll<Sprite>("Sprites/BufIconSheet/").Where(x => !BattleUnitBuf._bufIconDictionary.ContainsKey(x.name)))
                BattleUnitBuf._bufIconDictionary.Add(baseGameIcon.name, baseGameIcon);
            string bufIconDirectory = (path + "/ArtWork/BufIcons");
            if (Directory.Exists(bufIconDirectory))
            {
                var path = new DirectoryInfo(bufIconDirectory);
                if (path != null)
                {
                    LoadSpritesIntoDict(path, BufIcons);
                    foreach (var y in BufIcons.Where(x => !BattleUnitBuf._bufIconDictionary.ContainsKey(x.Key)))
                    {
                        BattleUnitBuf._bufIconDictionary.Add(y.Key, y.Value);
                    }
                }
            }
        }

        private static void LoadSpritesIntoDict(DirectoryInfo path, Dictionary<string, Sprite> dict)
        {
            if (path != null && Directory.Exists(path.FullName))
                foreach (var file in path.GetFiles().Where(x => x.Extension == ".png"))
                {
                    if (!dict.ContainsKey(Path.GetFileNameWithoutExtension(file.FullName)))
                    {
                        Texture2D texture2D = new Texture2D(2, 2);
                        texture2D.LoadImage(File.ReadAllBytes(file.FullName));
                        Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f));
                        dict.Add(Path.GetFileNameWithoutExtension(file.FullName), sprite);
                    }
                }
        }

        public static string path;
        public static bool Init;
        private static Dictionary<string, Sprite> BufIcons = new Dictionary<string, Sprite>();
    }
}
