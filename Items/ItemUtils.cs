using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace NonoMod.Items
{
	public static partial class ItemUtils
	{

		public static bool CheckMusketBalls(int type, Player player)
		{
			return type == ProjectileID.Bullet;
		}

    }

}
