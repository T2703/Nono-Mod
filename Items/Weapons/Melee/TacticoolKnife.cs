using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class TacticoolKnife : ModItem
	{
        // Make sure that this drops from an NPC.

        public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = 1;
			Item.knockBack = 1;
            Item.value = Item.buyPrice(silver: 72);
            Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextFloat() < 0.11f)
			{
                target.AddBuff(BuffID.Bleeding, 820);
            }
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.rand.NextFloat() < 0.11f)
            {
                target.AddBuff(BuffID.Bleeding, 820);
            }
        }


    }
}