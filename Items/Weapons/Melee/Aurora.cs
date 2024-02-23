using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class Aurora : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Melee;
			Item.width = 25;
			Item.height = 25;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = 1;
			Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 1, silver: 50);
            Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //base.MeleeEffects(player, hitbox);
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.HallowedWeapons, 0f, 0f, 0, Color.GhostWhite, 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 1f;
        }

    }
}