using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Buffs
{
	public class Unmotivated : ModBuff
	{

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.pvpBuff[Type] = true;

        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<UnmotivatedDOTNPC>().unmotivatedDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 1000;
        }

    }

    // This is for the NPCs.
    internal class UnmotivatedDOTNPC : GlobalNPC
    {
        public bool unmotivatedDebuff;
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            unmotivatedDebuff = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (unmotivatedDebuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 720;
                damage = 360;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (unmotivatedDebuff)
            {
                Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Firework_Blue, 0f, 0f, 10, Color.GhostWhite, 2f);
                dust.scale = 0.7f;
            }
        }
    }

    internal class UnmotivatedDOTPlayer : ModPlayer
    {
        public bool unmotivatedDebuff;

        public override void ResetEffects()
        {
            unmotivatedDebuff = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (unmotivatedDebuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }

                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 720;
            }
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (unmotivatedDebuff)
            {
                Dust dust = Dust.NewDustDirect(Player.position, Player.width, Player.height, DustID.Firework_Blue, 0f, 0f, 10, Color.GhostWhite, 2f);
                dust.scale = 0.7f;
            }
        }

    }


}