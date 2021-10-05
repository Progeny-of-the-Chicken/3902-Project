using System;

namespace Sprint_0.Scripts.Commands
{
    public class LinkChangeDirectionDown : ICommand
    {
        private Link link;

        public LinkChangeDirectionDown(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.GoInDirection(FacingDirection.Down);
        }
    }
}
