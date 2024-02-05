using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items
{
    public class LustCannon : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 70;
            Item.useTime = 5;
            Item.mana = 3;
            Item.useAnimation = 5;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.value = 1000005;
            Item.rare = 4;
            Item.UseSound = SoundID.Item4;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Flames;
            Item.shootSpeed = 21f;
            Item.noMelee = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.damage = 60;
                Item.mana = 12;
                Item.shootSpeed = 15f;
                Item.autoReuse = true;
                Item.knockBack = 12;
            }
            else
            {
                Item.damage = 45;
                Item.mana = 3;
                Item.shootSpeed = 21f;
                Item.autoReuse = true;
                Item.knockBack = 1;
            }

            return true;
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 1, velocity.Y * 1);
            position += offset;
            if (player.altFunctionUse == 2)
            {
                int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.IceBolt, damage, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;
                return false;
            }

            return true;
            
        }


        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Flamethrower, 1);
            recipe.AddIngredient(ItemID.IceRod, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}
