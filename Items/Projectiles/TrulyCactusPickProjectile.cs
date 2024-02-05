using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.CodeAnalysis;

namespace NonoMod.Items.Projectiles
{
	public class TrulyCactusPickProjectile : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 5;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.PaladinsHammerFriendly;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);


        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            target.AddBuff(BuffID.Poisoned, 360);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.Poisoned, 360);
        }



    }

}
