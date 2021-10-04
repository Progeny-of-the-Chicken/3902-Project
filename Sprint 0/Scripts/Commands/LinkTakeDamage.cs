using System;

namespace Sprint_0.Scripts.Commands
{
    public class LinkTakeDamage : ICommand
    {
        private Link link;

        public LinkTakeDamage(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.TakeDamage();
        }
    }
}
