using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using UltimateBoss.Content.Items.Boss;
using UltimateBoss.Content.Items.Placeable;
using UltimateBoss.Content.Items.Weapons;

namespace UltimateBoss.Content.NPCs
{
    [AutoloadHead]
    internal class NastyMan : ModNPC
    {
        public override string Texture
        {
            get { return "UltimateBoss/Content/NPCs/NastyMan"; }
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.Wood)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Uncle Nasty"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
  
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Wooden Arrow
            shop.item[nextSlot].SetDefaults(ItemID.PadThai, false);
            shop.item[nextSlot].value = 500;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Ale, false);
            shop.item[nextSlot].value = 100;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Bread>(), false);
            shop.item[nextSlot].value = 1000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MusicBox>(), false);
            shop.item[nextSlot].value = 100;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BingusKiller>(), false);
            shop.item[nextSlot].value = 5000;
            nextSlot++;

            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PaintingCursedSaint, false);
                nextSlot++;
            }
        }
        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<NastyMan>());
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Im watching you...";
                case 1:
                    return "Dont be getting up to any funny business";
                case 2:
                    return "Whats all this then";
                default:
                    return "Be careful.. Theres a Bingus around.";
            }
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 25;
            knockback = 2f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 2;
            randExtraCooldown = 10;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Wasp;
            attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.CrimsonCloak, 1, false, 0, false, false);
        }
    }
}
