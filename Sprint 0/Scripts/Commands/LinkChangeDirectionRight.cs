using System;

namespace Sprint_0.Scripts.Commands
{
    public class LinkChangeDirectionRight : ICommand
    {
        private Link link;

        public LinkChangeDirectionRight(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.GoInDirection(Direction.Right);
        }
    }
}
