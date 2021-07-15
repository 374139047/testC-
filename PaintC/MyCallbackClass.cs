using System;
//using PaintCoordinator;

namespace PaintClient
{
	public class MyCallbackClass: ReomteDelegateObject
	{
		public MyCallbackClass()
		{
		}

		protected override void InternalNewStrokeCallback(Stroke stroke) {
			MainForm myForm=MainForm.Instance();
			myForm.OnNewStroke(stroke);
		}

		public override object InitializeLifetimeService() {
			return null;
		}
	}
}
