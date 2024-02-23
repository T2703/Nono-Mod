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
	public class GrappleBlock : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.IceBlock);

        }

        public override void AI()
        {

        }


    }

}
