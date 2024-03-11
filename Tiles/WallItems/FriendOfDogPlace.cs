using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using static NonoMod.PlayerProp.PlayerGlobal;
using Terraria.ObjectData;

namespace NonoMod.Tiles.WallItems
{
    public class FriendOfDogPlace : ModTile
    {

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.addTile(Type);

            DustType = 7;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Main.SceneMetrics.HasSunflower = true;
        }

    }

}
