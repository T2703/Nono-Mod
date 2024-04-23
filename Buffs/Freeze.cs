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


}