using Microsoft.Xna.Framework;
using NonoMod.Buffs;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class GrimRipper : ModItem
	{
        // One of Dead Rising 3 broken weapons and I love it so I decided to make it I think.
        public override void SetDefaults()
		{
			Item.damage = 66;
			Item.DamageType = DamageClass.Melee;
			Item.width = 65;
			Item.height = 65;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 4.2f;
            Item.value = Item.buyPrice(gold: 55, silver: 90, copper: 50);
            Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SkullProjectile>();
            Item.shootSpeed = 16.6f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 0, default, 1f);
            Main.dust[dust].velocity *= 0.5f;
        }
                             
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 360);
        }

        public override void ModifyHitPvp(Player player, Player target, ref Player.HurtModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 360);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Hellstone, 50);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }

    }
}