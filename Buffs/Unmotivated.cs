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
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false; 

        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 50;
            player.lifeRegen = 120;
            player.moveSpeed += 0.20f;
            player.GetDamage(DamageClass.Generic) += 0.20f;
            player.GetCritChance(DamageClass.Generic) += 0.14f;


        }


    }
}