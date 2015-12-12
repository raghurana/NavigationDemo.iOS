using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace NavigationDemo.iOS
{
    public class ItemDetailViewController : UIViewController
    {
        private readonly int selectedItem;

        private UINavigationController nestedNavigationController;

        public ItemDetailViewController(int selectedItem)
        {
            this.selectedItem = selectedItem;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = $"Item { selectedItem } Details";

            EdgesForExtendedLayout = UIRectEdge.None;

            View.BackgroundColor = UIColor.Orange;

            var menu = new MyCustomMenu();
            menu.Button1Clicked += OnButton1Clicked;
            menu.Button2Clicked += OnButton2Clicked;
            View.Add(menu);

            nestedNavigationController = new UINavigationController();
            nestedNavigationController.NavigationBarHidden = true;
            View.Add(nestedNavigationController.View);   

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints
                (
                    menu.AtTopOf(View),
                    menu.AtLeftOf(View).Plus(10),
                    menu.WithSameLeft(View),
                    menu.WithSameRight(View),

                    nestedNavigationController.View.Below(menu),
                    nestedNavigationController.View.WithSameLeft(menu),
                    nestedNavigationController.View.WithSameRight(menu),
                    nestedNavigationController.View.WithSameBottom(View)
                );
        }

        private void OnButton1Clicked(object sender, EventArgs eventArgs)
        {
            nestedNavigationController.PushViewController(new Button1ViewController(), false);
        }

        private void OnButton2Clicked(object sender, EventArgs eventArgs)
        {
            nestedNavigationController.PushViewController(new Button2ViewController(), false);
        }
    }
}