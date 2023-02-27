using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using UltimateBoss.Content.NPCs.Bosses;
using UltimateBoss.Common.Systems;
using Terraria.Audio;

namespace UltimateBoss.Content.Items.Boss
{
    public class Bread : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slice of Bread");
            Tooltip.SetDefault("Used to Summon Bingus");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.LightRed;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.consumable = true;
        }



        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                SoundEngine.PlaySound(SoundID.Roar, player.position);
                NPC.SpawnOnPlayer(player.whoAmI, NPCType<Bingus>());
            }

            else
                NetMessage.SendData(MessageID.SpawnBoss, -1, -1, null, player.whoAmI, NPCType<Bingus>(), 0.0f, 0.0f, 0, 0, 0);
            return true;
        }
    }
}