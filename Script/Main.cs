using Godot;
using System;

// Author : Axel Elise

namespace Com.IsartDigital.ProjectName {
	
	public partial class Main : Node2D
	{
		public override void _Ready()
		{
			Parallax.GetInstance();
		}

		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

		}

		protected override void Dispose(bool pDisposing)
		{

		}
	}
}
