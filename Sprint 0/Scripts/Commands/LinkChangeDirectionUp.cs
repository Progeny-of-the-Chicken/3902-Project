using System;

namespace Sprint_0.Scripts.Commands
{
    public class LinkChangeDirectionUp: ICommand
    {
        private Link link;

        public LinkChangeDirectionUp(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.GoInDirection(FacingDirection.Up);
        }
    }
}
