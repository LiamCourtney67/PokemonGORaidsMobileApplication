namespace Assessment;

public partial class Player : ContentPage
{
    bool menuOut = false;   // This controls if the menu is currently open or not

    public Player()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Converts the player code to the correct format
    /// </summary>
    /// <param name="code">Player code</param>
    /// <returns>Correctly formatted player code</returns>
    private string ConvertPlayerCode(string code)
    {
        // Removes any spaces inside the string
        code = code.Replace(" ", "");

        // Checks if any - have been used in the string
        if (!code.Contains("-"))
        {
            // Adds -'s to the string to return as the correct format
            code = code.Substring(0, 4) + "-" + code.Substring(4, 4) + "-" + code.Substring(8, 4);
        }
        return code;
    }

    /// <summary>
    /// Checks if any text has been inputted in the input fields if so changes the border colour
    /// </summary>
    /// <param name="sender">The input field</param>
    /// <param name="e">When the text has been changed</param>
    private void InputTextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;
        // If the input field has text the background colour changes to blue if not it changes to red
        if (!string.IsNullOrEmpty(entry.Text))
        {
            Frame frame = (Frame)entry.Parent;
            frame.BorderColor = Color.FromArgb("3B4CCA");
        }
        else
        {
            Frame frame = (Frame)entry.Parent;
            frame.BorderColor = Color.FromArgb("FF0000");
        }
    }

    /// <summary>
    /// Resets the form to null values
    /// </summary>
    private void ResetForm()
    {
        // Resets the form
        playerName.Text = null;
        playerLevel.Text = null;
        playerCode.Text = null;
    }

    /// <summary>
    /// When the submit button has been clicked it stores any data if data is null or not in the correct format it sends an error
    /// </summary>
    /// <param name="sender">The button object</param>
    /// <param name="e">When the button has been pressed</param>
    private async void SubmitButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // Stores user input
            string name = playerName.Text;
            int level = Int32.Parse(playerLevel.Text);
            string code = ConvertPlayerCode(playerCode.Text);

            // Displays a complete alert to the user
            await DisplayAlert("Success", "Your player details have been updated.", "OK");

            // Resets the form.
            ResetForm();
        }
        catch (Exception)
        {
            // Displays an error message to the user
            await DisplayAlert("Something Went Wrong", "Try entering your details again. Make sure to fill every box and follow the correct format. If the text is red, this means that the box has been left empty.", "Try Again");
        }
    }

    /// <summary>
    /// When the submit button has been clicked it resets the form
    /// </summary>
    /// <param name="sender">The button object</param>
    /// <param name="e">When the button has been pressed</param>
    private void ResetButtonClicked(object sender, EventArgs e)
    {
        // Resets the form.
        ResetForm();
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