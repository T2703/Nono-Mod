using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class HakkaNoTogame : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 44;
			Item.DamageType = DamageClass.Melee;
            Item.width = 32;
			Item.height = 32;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 3.8f;
            Item.value = Item.buyPrice(gold: 4, silver: 45);
            Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            //Item.shoot = ProjectileID.Flames;
            Item.shoot = ModContent.ProjectileType<IceSpray>();
            Item.shootSpeed = 18f;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.IceRod, 0f, 0f, 0, default, 1.2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 1f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 800);
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.Frostburn, 800);
        }

        public override void AddRecipes()
        {
            Recipe recipeBlue = CreateRecipe();
            recipeBlue.AddIngredient(ItemID.Katana, 1);
            recipeBlue.AddIngredient(ItemID.FrostCore, 1);
            recipeBlue.AddIngredient(ItemID.SoulofLight, 15);
            recipeBlue.AddTile(TileID.MythrilAnvil);
            recipeBlue.Register();
        }

    }
}