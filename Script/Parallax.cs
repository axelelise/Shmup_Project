using System;
using System.Collections.Generic;
using Godot;

// Author : 

namespace Com.IsartDigital.ProjectName {
	
	public partial class Parallax : Node
	{

		static private Parallax instance;

        List<ParallaxLayer> layers = new List<ParallaxLayer>();
        List<float> layerSpeeds = new List<float>() { 5, 10, 15, 20 };

        const float SCOLL_SPEED = -15f;
        const float MAX_SCROLL_SPEED = -100f;
        const float MIN_SCROLL_SPEED = -10f;
        float currentScrollSpeed = -30f;

        const float MARGIN_X = 150f;
        const float MARGIN_Y = 50f;

        Timer spawnTimer = new Timer();
        float startWaitTime = 2f;

        private Parallax() { }

		static public Parallax GetInstance()
		{
			if (instance == null) instance = new Parallax();
			return instance;

		}

		public override void _Ready()
		{
			if (instance != null)
			{
				QueueFree();
				GD.Print(nameof(Parallax) + " Instance already exist, destroying the last added.");
				return;
			}
			instance = this;

			foreach (ParallaxLayer layer in GetChildren())
			{
				layers.Add(layer);
			}
            


        }

		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

            int lLength = layers.Count - 1;
            for (int i = 0; i < lLength; i++)
            {
                layers[i].MotionOffset += new Vector2(layerSpeeds[i], 0) * lDelta * currentScrollSpeed;
            }
        }

		protected override void Dispose(bool pDisposing)
		{
			instance = null;
			base.Dispose(pDisposing);
		}
	}
}
