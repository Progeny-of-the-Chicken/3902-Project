﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class NorthLockedSprite : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(881, 11, 32, 32);
    Rectangle destination;
    LockedDoorCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;

    public NorthLockedSprite(Vector2 screenLocation, Room room)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        collider = new LockedDoorCollider(this, destination);
        this.room = room;
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D texture = TerrainSpriteFactory.Instance.GetDungeonSpritesheet();
        spriteBatch.Draw(texture, destination, spritesheetLocation, Color.White);
    }

    public void SwapDoor()
    {
        CommandSwapDoor command = new CommandSwapDoor(room, this, "NorthDoorSprite");
        command.Execute();
    }
}