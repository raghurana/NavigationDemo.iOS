using UIKit;

namespace NavigationDemo.iOS
{
    public class HomeViewController : UITabBarController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TabBar.Translucent = false;
            TabBar.TintColor = UIColor.Red;

            var vc1 = new UINavigationController(new TabOneController { Title = "Tab One" });
            var vc2 = new TabTwoViewController { Title = "Tab Two" };

            ViewControllers = new UIViewController[] {vc1, vc2};
            SelectedViewController = vc1;
        }
    }
}
