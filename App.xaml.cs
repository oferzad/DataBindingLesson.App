namespace DataBindingLesson;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new SimpleDataBinding();
        MainPage = new BindingWithHomeMadeClasses();
    }
}
