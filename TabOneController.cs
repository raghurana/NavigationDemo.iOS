using System;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using UIKit;

namespace NavigationDemo.iOS
{
    public class TabOneController : UIViewController
    {
        private UITableView tableView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Green;

            EdgesForExtendedLayout = UIRectEdge.None;
            NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            var data = new[] {"Item 1", "Item 2", "Item 3"};

            tableView = new UITableView();
            tableView.Source = new SimpleTableSource(data, OnItemSelected);
            tableView.RowHeight = UITableView.AutomaticDimension;
            tableView.EstimatedRowHeight = 40f;

            View.Add(tableView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(tableView.WithSameEverything(View));
        }

        private void OnItemSelected(int index)
        {
            NavigationController.PushViewController(new ItemDetailViewController(index), true);
        }
    }

    public class SimpleTableSource : UITableViewSource
    {
        private const string CellId = "myCell";

        private readonly string[] data;
        private readonly Action<int> selectedRowAction;

        public SimpleTableSource(string[] data, Action<int> selectedRowAction)
        {
            this.data = data;
            this.selectedRowAction = selectedRowAction;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellId) ?? new UITableViewCell(UITableViewCellStyle.Default, CellId);
            cell.TextLabel.Text = data[indexPath.Row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            selectedRowAction?.Invoke(indexPath.Row + 1);
        }
    }
}