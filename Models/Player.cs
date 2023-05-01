using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Controllers;

namespace Platformer.Models;

public class Player {
    private Vector2 _position;
    private Vector2 _velocity;
    private readonly float _speed;
    private readonly AnimationController _animationController;

    public Player(Game game) {
        _speed = 1000f;
        _position = new Vector2(100, 100);
        
        // Animations
        _animationController = new AnimationController();
        
        _animationController.AddAnimation(new Vector2(0, 0), new Animation(game.Content.Load<Texture2D>("idle"), 10, .1f));
        _animationController.AddAnimation(new Vector2(1, 0), new Animation(game.Content.Load<Texture2D>("walk"), 8, .1f));
        _animationController.AddAnimation(new Vector2(-1, 0), new Animation(game.Content.Load<Texture2D>("walk"), 8, .1f));
    }

    public void Update(GameTime gameTime) {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (InputController.Moving)
            _velocity.X += InputController.Direction.X * _speed * deltaTime;

        _position += _velocity * deltaTime;
        // _velocity.Y += 9.82f * deltaTime;
        _velocity.X *= 0.9f;
        _animationController.Update(gameTime, InputController.Direction);
    }

    public void Draw(SpriteBatch spriteBatch) {
        _animationController.Draw(spriteBatch, _position, _velocity.X < 0);
    }
}