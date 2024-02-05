using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Buffs
{
	public class Motivation : ModBuff
	{
        // Now I'm a little motivated.
        // Kinda like DT I suppose.

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {


        }


    }
}