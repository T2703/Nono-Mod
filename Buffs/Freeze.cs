using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Buffs
{
	public class Freeze : ModBuff
	{
        // My way of making enemies freeze.
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.pvpBuff[Type] = true;

        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity *= 0;
        }
    }

    internal class freezeNPC : GlobalNPC
    {
        public bool freezeDebuff;
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            freezeDebuff = false;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (freezeDebuff)
            {
                Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.SnowflakeIce, 0f, 0f, 10, Color.GhostWhite, 2f);
                dust.scale = 0.7f;
            }
        }
    }


}