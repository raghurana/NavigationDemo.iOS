using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace NavigationDemo.iOS
{
    public class Button1ViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Button 1 Controller";
            View.BackgroundColor = UIColor.Yellow;

            var headerLabel = new UILabel {Text = "Button 1 View Controller "};
            View.Add(headerLabel);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(headerLabel.WithSameEverything(headerLabel));
        }
    }
}
