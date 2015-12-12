using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace NavigationDemo.iOS
{
    public class TabTwoViewController : UIViewController
    {
        private UILabel placeHolderLabel;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Cyan;

            placeHolderLabel = new UILabel {Text = "Placeholder for Tab two view"};
            View.Add(placeHolderLabel);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(placeHolderLabel.WithSameEverything(View));
        }
    }
}