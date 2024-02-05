using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using NonoMod.Items.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class CoffeeAndCream : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = 1;
			Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = 4;
			Item.autoReuse = true;
            Item.UseSound = SoundID.Item71;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.FireworkFountain_Pink, 0.2f, 0f, 0, default, 1f);
            Main.dust[dust].noGravity = true;
            Lighting.AddLight(Item.Center, 2f, 0.5f, 0.5f);
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var source = player.GetSource_ItemUse(Item);
            float randomValue = Main.rand.NextFloat(-7f, 7f);

            if (player.direction == 1)
            {
                Projectile.NewProjectile(source, target.position.X, target.position.Y, player.direction + 7, randomValue, 521, Item.damage / 2 , 1, player.whoAmI);
            }
            else if (player.direction == -1) 
            {
                Projectile.NewProjectile(source, target.position.X, target.position.Y, player.direction - 7, randomValue, 521, Item.damage / 2, 1, player.whoAmI);
            }

            // I could just rework the Number One code to be like this but now I don't want to.
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            var source = player.GetSource_ItemUse(Item);
            float randomValue = Main.rand.NextFloat(-7f, 7f);

            if (player.direction == 1)
            {
                Projectile.NewProjectile(source, target.position.X, target.position.Y, player.direction + 7, randomValue, 521, Item.damage / 2, 1, player.whoAmI);
            }
            else if (player.direction == -1)
            {
                Projectile.NewProjectile(source, target.position.X, target.position.Y, player.direction - 7, randomValue, 521, Item.damage / 2, 1, player.whoAmI);
            }
        }

    }
}