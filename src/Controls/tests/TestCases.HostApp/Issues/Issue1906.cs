namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Github, 1906, "AlertView doesn't scroll when text is too large", PlatformAffected.iOS | PlatformAffected.Android)]
	public class Issue1906 : Microsoft.Maui.Controls.NavigationPage
	{
		public Issue1906() : base(new MainPage())
		{
		}
		public class MainPage : ContentPage
		{
			public MainPage()
			{
				var btn = new Button { Text = "Show alert" };
				btn.Clicked += async (object sender, EventArgs e) =>
				{
					await DisplayAlert("Long Message", "Start - kajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfjkajsd;lfkjals;kddfjkl;asdadjsf;lkasjdfl;kasjdf;lkajsd;flkjasd;flkjasd;lkdfjkakls;dfjkl;asdjfkl;asdjfl;kasdjadsfkl;asjdfl;kajadjs;flkjasdl;fklf;jas;dlkjf;alskdjdfakl;sddfjsakls;djfjl;aksdadfjsl;kasdjadsfl;kasdadfjskl;asjdfl;kasdjfl;kasdjfl;kasjdfl;kasjdfkl;asjdfl;kasjdfl;kasjdfl;kasjdfkl;ajsdl;kfkl;jsadkl;fjklasl;dkfjals;kdfjals;kdjfals;kdfalksjdflkajsd;lkfjasl;dkdfjk;alskdjdfjal;skjdfl;askjdfl;aksjdfakl;sdjfkl;asjdfkl;asjdfl;kajsdfl;kajsdfl;kajsdl;ffkl;jasdl;kkl;dfjadls;kdfjkals;kdjkadfsal;ksdjdfal;skddfjal;skdfjal;skdjfal;ksdfjakls;djdfakls;dfjl;askdfjal;skdjfakls;dfj - End", "Ok", "Cancel");
				};

				Content = btn;
			}

			protected override void OnAppearing()
			{

				base.OnAppearing();
			}
		}
	}
}