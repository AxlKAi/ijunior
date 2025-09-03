﻿using ConsoleGUI.Common;
using ConsoleGUI.Space;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGUI.Test.Common
{
	internal abstract class TestControl : Control
	{
		public new FreezeContext Freeze() => base.Freeze();
		public new void Update(in Rect rect) => base.Update(rect);
		public new void Redraw() => base.Redraw();
		public new void Resize(in Size size) => base.Resize(size);
	}

	[TestFixture]
	public class ControlTest
	{
		[Test]
		public void Control_DoesntUpdate_WhenFrozen()
		{
			var context = new Mock<IDrawingContext>();
			context.SetupGet(c => c.MinSize).Returns(new Size(20, 20));
			context.SetupGet(c => c.MaxSize).Returns(new Size(20, 20));

			var control = new Mock<TestControl>();
			(control.Object as IControl).Context = context.Object;

			control.Object.Freeze();
			control.Object.Update(new Rect(2, 3, 10, 11));

			context.Verify(c => c.Update(control.Object, It.IsAny<Rect>()), Times.Never);
		}

		[Test]
		public void Control_Updates_WhenUnfrozen()
		{
			var context = new Mock<IDrawingContext>();
			context.SetupGet(c => c.MinSize).Returns(new Size(20, 20));
			context.SetupGet(c => c.MaxSize).Returns(new Size(20, 20));

			var control = new Mock<TestControl>();
			(control.Object as IControl).Context = context.Object;

			using (control.Object.Freeze())
				control.Object.Update(new Rect(2, 3, 10, 11));

			context.Verify(c => c.Update(control.Object, new Rect(2, 3, 10, 11)), Times.Once);
		}

		[Test]
		public void Control_Updates_OnlyOnceAfterUnfrozen()
		{
			var context = new Mock<IDrawingContext>();
			context.SetupGet(c => c.MinSize).Returns(new Size(20, 20));
			context.SetupGet(c => c.MaxSize).Returns(new Size(20, 20));

			var control = new Mock<TestControl>();
			(control.Object as IControl).Context = context.Object;
			context.Reset();

			using (control.Object.Freeze())
			{
				control.Object.Update(new Rect(2, 3, 10, 11));
				control.Object.Update(new Rect(1, 1, 2, 4));
			}

			context.Verify(c => c.Update(control.Object, It.Ref<Rect>.IsAny), Times.Once);
		}

		[Test]
		public void Control_Updates_AllUpdatedCellsAfterUnfrozen()
		{
			var context = new Mock<IDrawingContext>();
			context.SetupGet(c => c.MinSize).Returns(new Size(20, 20));
			context.SetupGet(c => c.MaxSize).Returns(new Size(20, 20));

			var control = new Mock<TestControl>();
			(control.Object as IControl).Context = context.Object;
			context.Reset();

			using (control.Object.Freeze())
			{
				control.Object.Update(new Rect(2, 3, 10, 11));
				control.Object.Update(new Rect(1, 1, 2, 4));
			}

			context.Verify(c => c.Update(control.Object, new Rect(1, 1, 11, 13)), Times.Once);
		}

		[Test]
		public void Control_Redraws_IfAskedToRedraw()
		{
			var context = new Mock<IDrawingContext>();
			context.SetupGet(c => c.MinSize).Returns(new Size(20, 20));
			context.SetupGet(c => c.MaxSize).Returns(new Size(20, 20));

			var control = new Mock<TestControl>();
			(control.Object as IControl).Context = context.Object;
			context.Reset();

			using (control.Object.Freeze())
			{
				control.Object.Update(new Rect(2, 3, 10, 11));
				control.Object.Redraw();
				control.Object.Update(new Rect(1, 1, 2, 4));
			}

			context.Verify(c => c.Redraw(control.Object));
			context.Verify(c => c.Update(control.Object, It.Ref<Rect>.IsAny), Times.Never);
		}

		[Test]
		public void Control_Updates_RedrawsIfSizeChanged()
		{
			var context = new Mock<IDrawingContext>();
			context.SetupGet(c => c.MinSize).Returns(new Size(20, 20));
			context.SetupGet(c => c.MaxSize).Returns(new Size(40, 40));

			var control = new Mock<TestControl>();
			(control.Object as IControl).Context = context.Object;
			control.Object.Resize(new Size(30, 30));
			context.Reset();

			control.Object.Resize(new Size(35, 35));

			context.Verify(c => c.Redraw(control.Object));
			context.Verify(c => c.Update(control.Object, It.Ref<Rect>.IsAny), Times.Never);
		}

		[Test]
		public void Control_Updates_UpdatedIfSizeDidintChange()
		{
			var context = new Mock<IDrawingContext>();
			context.SetupGet(c => c.MinSize).Returns(new Size(20, 20));
			context.SetupGet(c => c.MaxSize).Returns(new Size(40, 40));

			var control = new Mock<TestControl>();
			(control.Object as IControl).Context = context.Object;
			control.Object.Resize(new Size(30, 30));
			context.Reset();

			using (control.Object.Freeze())
			{
				control.Object.Resize(new Size(35, 35));
				control.Object.Resize(new Size(30, 30));
			}

			context.Verify(c => c.Redraw(control.Object), Times.Never);
			context.Verify(c => c.Update(control.Object, It.Ref<Rect>.IsAny), Times.Once);
			context.Verify(c => c.Update(control.Object, new Rect(0, 0, 30, 30)), Times.Once);
		}
	}
}
