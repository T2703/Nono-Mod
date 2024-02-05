using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class WritingOnTheWall : ModItem
	{
        // Senjustu has gotta be a favorite Iron Maiden album of mine. Samurai Eddie is badass.	

        public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(gold: 1, silver: 70);
            Item.rare = 3;
			Item.autoReuse = true;
            Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/WritingOnTheWallSlashSFX")
            {
                Volume = 0.6f,
                PitchVariance = 0.5f,
                MaxInstances = 10,
            };

        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var source = player.GetSource_ItemUse(Item);
			float posY = player.position.Y - 400f;
            for (int i = 0; i < 2; i++) 
			{
                float randomValue = Main.rand.NextFloat(-8f, 8f);
                float randomX = (float)(5f + (10f * new Random().NextDouble()));
                Projectile.NewProjectile(source, target.position.X + randomX, posY, randomValue, 50f, ProjectileID.WoodenArrowFriendly, 5, 1, player.whoAmI);

            }
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            var source = player.GetSource_ItemUse(Item);
            float posY = player.position.Y - 400f;
            for (int i = 0; i < 2; i++)
            {
                float randomValue = Main.rand.NextFloat(-8f, 8f);
                float randomX = (float)(5f + (10f * new Random().NextDouble()));
                Projectile.NewProjectile(source, target.position.X + randomX, posY, randomValue, 50f, ProjectileID.WoodenArrowFriendly, 5, 1, player.whoAmI);

            }
        }
    }
}