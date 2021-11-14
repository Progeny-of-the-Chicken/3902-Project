using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Sprint_0.Scripts.Commands
{
    class ToggleMute : ICommand
    { 
        public void Execute()
        {
            if(SoundEffect.MasterVolume == 0)
            {
                SoundEffect.MasterVolume = 1;
            }
            else
            {
                SoundEffect.MasterVolume = 0;
            }
        }
    }
}
