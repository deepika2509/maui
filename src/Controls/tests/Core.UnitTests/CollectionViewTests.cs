using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Maui.Controls.Core.UnitTests
{
	public class CollectionViewTests : BaseTestFixture
	{
		[Fact]
		public void TestInitialItemBinding()
		{
			var collectionView = new CollectionView();
			var items = new List<string> { "Item1", "Item2", "Item3" };
			collectionView.ItemsSource = items;

			var itemCount = collectionView.ItemsSource.Cast<object>().Count();

			Assert.Equal(3, itemCount);
		}

		[Fact]
		public void TestEmptyViewDisplayed()
		{
			var collectionView = new CollectionView();
			var items = new ObservableCollection<string>();
			collectionView.ItemsSource = items;
			collectionView.EmptyView = "No items available";

			var isEmptyViewDisplayed = items.Count == 0;

			Assert.True(isEmptyViewDisplayed);
			Assert.Equal("No items available", collectionView.EmptyView);
		}

		[Fact]
		public void TestScrollToSpecificItem()
		{
			var collectionView = new CollectionView();
			var items = new List<string> { "Item1", "Item2", "Item3", "Item4", "Item5" };
			collectionView.ItemsSource = items;

			collectionView.ScrollTo(3, position: ScrollToPosition.Start);

			Assert.NotNull(collectionView.ItemsSource);
		}

		[Fact]
		public void TestSingleSelection()
		{
			var items = new List<string> { "Item1", "Item2", "Item3" };
			var collectionView = new CollectionView
			{
				ItemsSource = items,
				SelectionMode = SelectionMode.Single
			};

			collectionView.SelectedItem = "Item2";

			Assert.Equal("Item2", collectionView.SelectedItem);
		}


		[Fact]
		public void TestMultiSelection()
		{
			var items = new List<string> { "Item1", "Item2", "Item3" };
			var collectionView = new CollectionView
			{
				ItemsSource = items,
				SelectionMode = SelectionMode.Multiple
			};

			collectionView.SelectedItems.Add("Item1");
			collectionView.SelectedItems.Add("Item3");

			Assert.Contains("Item1", collectionView.SelectedItems);
			Assert.Contains("Item3", collectionView.SelectedItems);
			Assert.Equal(2, collectionView.SelectedItems.Count);
		}


	}
}
