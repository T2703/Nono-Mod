using Microsoft.Xna.Framework;
using NonoMod.PlayerProp;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Accessories
{
	public class GiftCard : ModItem
	{
        // Forntie gift card 20 dollar real who want it?

        public override void SetDefaults()
		{
            Item.width = 41;
            Item.height = 41;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(silver: 20, copper: 20);
            Item.rare = 3;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.07f;

        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.10f;
        }

    }
}