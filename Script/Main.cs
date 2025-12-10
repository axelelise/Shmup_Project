using Godot;
using System;

// Author : 

namespace Com.IsartDigital.ProjectName {
	
	public partial class Main : Node2D
	{

		static private Main instance;
        [Export] private ParallaxBackground background;
		[Export] private PackedScene playerScene;
		[Export] private int speed = 500;

        Vector2 screenSize;
        private Main() { }

		static public Main GetInstance()
		{
			if (instance == null) instance = new Main();
			return instance;

		}

		public override void _Ready()
		{
			base._Ready();
			if (instance != null)
			{
				QueueFree();
				GD.Print(nameof(Main) + " Instance already exist, destroying the last added.");
				return;
			}

            screenSize = GetWindow().Size;
            instance = this;
			CreatePlayer();

		}

		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

            background.ScrollOffset += new Vector2(-speed * lDelta, 0);
        }

		protected override void Dispose(bool pDisposing)
		{
			instance = null;
			base.Dispose(pDisposing);
		}

        public Player CreatePlayer()
		{
			Player lPlayer = (Player)playerScene.Instantiate();
			AddChild(lPlayer);
			lPlayer.Position = new Vector2(screenSize.X / 2, screenSize.Y / 2);
            return lPlayer;
		}

    }
}
