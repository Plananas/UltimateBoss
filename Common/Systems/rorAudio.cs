using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;


namespace UltimateBoss.Common.Systems
{
    internal class rorAudio : ModSystem
    {
        public static readonly IAudioTrack BingusTheme;


        static rorAudio()
        {
            BingusTheme = MusicLoader.GetMusic("UltimateBoss/Assets/Music/Test");



        }

    }
}
