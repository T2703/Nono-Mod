using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class AngelThanatos : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 135;
			Item.DamageType = DamageClass.Melee;
			Item.width = 80;
			Item.height = 80;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 10;
            Item.value = Item.buyPrice(gold: 18, silver: 45, copper: 99);
            Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var source = player.GetSource_ItemUse(Item);
            float randomValue = Main.rand.NextFloat(-7f, 7f);
            //Projectile.NewProjectile(source, target.position.X, target.position.Y, player.direction + 10, 0, 494, Item.damage / 2, 5, player.whoAmI);
            Projectile.NewProjectile(source, target.position.X, target.position.Y, player.direction + 10, 0, ModContent.ProjectileType<Guilt>(), Item.damage / 2, 5, player.whoAmI);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 2f);
        }

    }
}