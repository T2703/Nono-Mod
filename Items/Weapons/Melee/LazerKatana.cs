using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class LazerKatana : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 1;
			Item.knockBack = 2.3f;
            Item.value = Item.buyPrice(gold: 21);
            Item.rare = 4;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = true;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //base.MeleeEffects(player, hitbox);
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.GreenFairy, 0f, 0f, 0, default, 1f);
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var source = player.GetSource_ItemUse(Item);
            Projectile.NewProjectile(source, target.position.X, target.position.Y, 12, 0, ModContent.ProjectileType<GreenKatanaBeam>(), Item.damage, Item.knockBack, player.whoAmI);
            Projectile.NewProjectile(source, target.position.X, target.position.Y, -12, 0, ModContent.ProjectileType<GreenKatanaBeam>(), Item.damage, Item.knockBack, player.whoAmI);
        }

    }
}