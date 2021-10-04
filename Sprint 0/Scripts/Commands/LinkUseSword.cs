using System;

namespace Sprint_0.Scripts.Commands
{
    public class LinkUseSword : ICommand
    {
        private Link link;

        public LinkUseSword(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.UseSword();
        }
    }
}
