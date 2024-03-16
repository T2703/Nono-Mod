using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Buffs
{
	public class Damn : ModBuff
	{

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.pvpBuff[Type] = true;

        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<DamnDOTNPC>().damnDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 16;
        }

    }

    // This is for the NPCs.
    internal class DamnDOTNPC : GlobalNPC
    {
        public bool damnDebuff;
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            damnDebuff = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (damnDebuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 12;
                damage = 1;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (damnDebuff)
            {
                Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.TreasureSparkle, 0f, 0f, 10, Color.White, 2f);
                dust.scale = 0.5f;
            }
        }
    }

    internal class DamnDOTPlayer : ModPlayer
    {
        public bool damnDebuff;

        public override void ResetEffects()
        {
            damnDebuff = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (damnDebuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }

                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 12;
            }
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (damnDebuff)
            {
                Dust dust = Dust.NewDustDirect(Player.position, Player.width, Player.height, DustID.RainbowRod, 0f, 0f, 10, Color.White, 2f);
                dust.scale = 0.5f;
            }
        }

    }


}