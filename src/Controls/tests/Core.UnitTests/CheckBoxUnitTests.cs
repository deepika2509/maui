using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using static Microsoft.Maui.Controls.Core.UnitTests.VisualStateTestHelpers;

namespace Microsoft.Maui.Controls.Core.UnitTests
{

	public class CheckBoxUnitTests : BaseTestFixture
	{
		[Fact]
		public void TestConstructor()
		{
			var checkBox = new CheckBox();

			Assert.False(checkBox.IsChecked);
		}

		[Fact]
		public void TestOnEvent()
		{
			var checkBox = new CheckBox();

			var fired = false;
			checkBox.CheckedChanged += (sender, e) => fired = true;

			checkBox.IsChecked = true;

			Assert.True(fired);
		}

		[Fact]
		public void TestOnEventNotDoubleFired()
		{
			var checkBox = new CheckBox();

			bool fired = false;
			checkBox.IsChecked = true;

			checkBox.CheckedChanged += (sender, args) => fired = true;
			checkBox.IsChecked = true;

			Assert.False(fired);
		}

		[Fact]
		public void CheckedVisualStates()
		{
			var vsgList = CreateTestStateGroups();
			string checkedStateName = CheckBox.IsCheckedVisualState;
			var checkedState = new VisualState() { Name = checkedStateName };
			var stateGroup = vsgList[0];
			stateGroup.States.Add(checkedState);

			var element = new CheckBox();
			VisualStateManager.SetVisualStateGroups(element, vsgList);

			element.IsChecked = true;
			Assert.Equal(checkedStateName, stateGroup.CurrentState.Name);

			element.IsChecked = false;
			Assert.NotEqual(checkedStateName, stateGroup.CurrentState.Name);
		}
		[Fact]
		public void TestIsCheckedToggleMultipleTimes()
		{
			var checkBox = new CheckBox();

			checkBox.IsChecked = true;
			Assert.True(checkBox.IsChecked);

			checkBox.IsChecked = false;
			Assert.False(checkBox.IsChecked);

			checkBox.IsChecked = true;
			Assert.True(checkBox.IsChecked);
		}

		[Fact]
		public void TestStatePersistenceOnVisibilityToggle()
		{
			var checkBox = new CheckBox { IsChecked = true };

			checkBox.IsVisible = false;
			checkBox.IsVisible = true;

			Assert.True(checkBox.IsChecked);
		}

		[Fact]
		public void TestUncheckedEventTrigger()
		{
			var checkBox = new CheckBox { IsChecked = true };
			var eventTriggered = false;

			checkBox.CheckedChanged += (sender, e) => eventTriggered = true;

			checkBox.IsChecked = false;

			Assert.True(eventTriggered);
		}
	}
}
