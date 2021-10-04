using System;

namespace Sprint_0.Scripts.Commands
{
    public class LinkChangeDirectionLeft : ICommand
    {
        private Link link;

        public LinkChangeDirectionLeft(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.GoInDirection(Direction.Left);
        }
    }
}
