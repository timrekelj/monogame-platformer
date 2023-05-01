using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Models;

namespace Platformer.Controllers;

public class AnimationController {
    private readonly Dictionary<object, Animation> _anims = new();
    private object _lastKey;

    public void AddAnimation(object key, Animation animation) {
        _anims.Add(key, animation);
        _lastKey = key;
    }

    public void Update(GameTime gameTime, object key) {
        if (_anims.TryGetValue(key, out Animation value)) {
            value.Start();
            _anims[key].Update(gameTime);
            _lastKey = key;
        } else {
            _anims[_lastKey].Stop();
            _anims[_lastKey].Reset();
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool flipped = false) {
        _anims[_lastKey].Draw(position, spriteBatch, flipped);
    }
}