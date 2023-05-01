using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Controllers; 

public sealed class ScreenController {
    private static int _width;
    private static int _height;
    
    private bool _isDisposed;
    private Game _game;
    private RenderTarget2D _renderTarget;
    private bool _isSet;
    
    public ScreenController(Game game) {
        _game = game;
        _width = 640; 
        _height = 360;
        
        _game = game ?? throw new ArgumentNullException("game");
        
        _renderTarget = new RenderTarget2D(_game.GraphicsDevice, _width, _height);
    }
    
    public void Set() {
        if (_isSet) throw new InvalidOperationException("Render target is already set");
        _game.GraphicsDevice.SetRenderTarget(_renderTarget);
        _isSet = true;
    }
    
    public void UnSet() {
        if (!_isSet) throw new InvalidOperationException("Render target is already unset");
        _game.GraphicsDevice.SetRenderTarget(null);
        _isSet = false;
    }

    public void Present(SpriteBatch spriteBatch, bool textureFiltering = false) {
        if (spriteBatch is null) throw new ArgumentNullException("spriteBatch");
        
        _game.GraphicsDevice.Clear(Color.Pink);
        
        spriteBatch.Begin(samplerState: SamplerState.PointWrap);
        spriteBatch.Draw(_renderTarget, CalculateDestinationRectangle(), Color.White);
        spriteBatch.End();
    }

    private Rectangle CalculateDestinationRectangle() {
        Rectangle backbufferBounds = _game.GraphicsDevice.PresentationParameters.Bounds;
        float backbufferAspectRatio = (float)backbufferBounds.Width / backbufferBounds.Height;
        float renderTargetAspectRatio = (float)_width / _height;
        float rx = 0;
        float ry = 0;
        float rw = backbufferBounds.Width;
        float rh = backbufferBounds.Height;

        if (backbufferAspectRatio > renderTargetAspectRatio) {
            rw = rh * renderTargetAspectRatio;
            rx = (backbufferBounds.Width - rw) / 2f;
        } else if (backbufferAspectRatio < renderTargetAspectRatio) {
            rh = rw / renderTargetAspectRatio;
            ry = (backbufferBounds.Height - rh) / 2f; 
        }

        return new Rectangle((int)rx, (int)ry, (int)rw, (int)rh);
    }
}