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
            //Do we even use this command?
            //Should we even use this command? We need link to be able to take various amounts of damage from different enemies
            link.TakeDamage(ObjectConstants.KeeseDamage);
        }
    }
}
