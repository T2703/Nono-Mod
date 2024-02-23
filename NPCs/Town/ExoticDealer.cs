using Microsoft.Xna.Framework;
using NonoMod.Items;
using NonoMod.Items.Weapons.Magic;
using NonoMod.Items.Weapons.Melee;
using NonoMod.Items.Weapons.Ranged;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace NonoMod.NPCs.Town
{
    [AutoloadHead]
    public class ExoticDealer : ModNPC
	{
        public const string ShopName = "Shop";
        public override void SetDefaults()
        {
            Main.npcFrameCount[Type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 450;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 29;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;

            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defDefense = 16;
            NPC.lifeMax = 251;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.6f;

            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if (!player.active)
                {
                    continue;
                }

                if (numTownNPCs >= 5)
                {
                    return true;
                }
            }

            return false;
            
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Jordie",
                "Kai",
                "Brody",
                "Jay",
                "Cody",
                "Frankie",
                "Venom",
                "Cobra"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            shopName = ShopName;
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add<Items.Weapons.Ranged.BigAndHeavy>()
                .Add<Items.Weapons.Ranged.MachinePistol>()
                .Add<Items.Weapons.Melee.LazerKatana>();
            npcShop.Register();
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<ExoticDealer>());
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Swords, guns, and magic? I got you covered!";
                case 1:
                    return "Ready to see some real weapons?";
                case 2:
                    return "You better have money if you want some exotic weapons.";
                default:
                    return "Hello.";
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TacticoolKnife>(), 3, 1, 1));

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A dealer who sells all types of exotic weapons. Swords, guns, magic he'll have you covered but, at a price."),
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Wraith, 0f, 0f, 10, Color.GhostWhite, 1f);
                dust.velocity *= 1f;
            }
        }

    }
}