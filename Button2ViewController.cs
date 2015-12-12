using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace NavigationDemo.iOS
{
    public class Button2ViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Button 2 Controller";
            View.BackgroundColor = UIColor.LightGray;

            var headerLabel = new UILabel { Text = "Button 2 View Controller" };
            View.Add(headerLabel);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(headerLabel.WithSameEverything(headerLabel));
        }
    }
}