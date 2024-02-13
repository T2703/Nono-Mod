using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class GoodTastyChicken : ModItem
	{
        

        public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 5f;
            Item.value = Item.buyPrice(silver: 30, copper: 23);
            Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;

        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            player.AddBuff(BuffID.WellFed, 120);
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
           player.AddBuff(BuffID.WellFed, 120);
        }

    }
}