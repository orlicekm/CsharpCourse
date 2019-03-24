namespace OpeningWindow.Views
{
    public class NewViewBase : IView
    {
        public void Show()
        {
            // Here can be switch for more options
            // e.g. Depends on application settings
            new NewView().Show();
        }
    }
}