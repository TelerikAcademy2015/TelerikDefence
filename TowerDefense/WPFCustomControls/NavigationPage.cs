namespace TowerDefense.WPFCustomControls
{
    using System.Windows;
    using System.Windows.Controls;

    public class NavigationPage : PropertyChangedAwaredPage
    {
        protected void NavigateToPage(Page page)
        {
            ((Window)this.Parent).Content = page;
        }
    }
}
