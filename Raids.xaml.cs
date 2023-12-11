namespace Assessment;

public partial class Raids : ContentPage
{
    bool menuOut = false;   // This controls if the menu is currently open or not

    public Raids()
    {
        InitializeComponent();
    }

    /// <summary>
    /// This opens and closes the menu button to reveal navigation
    /// </summary>
    /// <param name="sender">The button object></param>
    /// <param name="e">When the button has been pressed</param>
    private async void Button_Clicked(object sender, EventArgs e)
    {
        // This hides and reveals the navigation menu
        if (menuOut)
        {
            menuContainer.Opacity = 0;

            await menuTop.TranslateTo(0, 0, 200);

            menuOut = false;
        }
        else
        {
            await menuTop.TranslateTo(0, -240, 200);

            await menuContainer.FadeTo(1, 400);
            menuOut = true;
        }
    }

    /// <summary>
    /// This opens the home page
    /// </summary>
    /// <param name="sender">The button object</param>
    /// <param name="e">When the button has been pressed</param>
    private async void HomePageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    /// <summary>
    /// This opens the raids page
    /// </summary>
    /// <param name="sender">The button object</param>
    /// <param name="e">When the button has been pressed</param>
    private async void RaidsPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Raids());
    }

    /// <summary>
    /// This opens the friends page
    /// </summary>
    /// <param name="sender">The button object</param>
    /// <param name="e">When the button has been pressed</param>
    private async void FriendsPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Friends());
    }

    /// <summary>
    /// This opens the types page
    /// </summary>
    /// <param name="sender">The button object</param>
    /// <param name="e">When the button has been pressed</param>
    private async void TypesPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Types());
    }

    /// <summary>
    /// This opens the player info page
    /// </summary>
    /// <param name="sender">The button object</param>
    /// <param name="e">When the button has been pressed</param>
    private async void PlayerPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Player());
    }
}