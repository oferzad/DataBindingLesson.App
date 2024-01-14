using System.ComponentModel;
using System.Windows.Input;

namespace DataBindingLesson;

class Student : INotifyPropertyChanged
{
    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    public Student()
    {
        ButtonCommand = new Command(() => ChangeName(), ()=>firstName=="Uri");
    }

    private string firstName;
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
            OnPropertyChanged();
        }
    }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int AverageScore { get; set; }

    public Command ButtonCommand { get; set; }

    private void ChangeName()
    {
        this.FirstName = "Kuku";
        ButtonCommand.ChangeCanExecute();

    }
}

public partial class BindingWithHomeMadeClasses : ContentPage
{
    Student uri;
    public BindingWithHomeMadeClasses()
	{
		InitializeComponent();
        uri = new Student
        {
            FirstName = "Uri",
            LastName = "Zadikario",
            BirthDate = new DateTime(2006, 2, 21),
            AverageScore = 85

        };
        BindingContext = uri;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        uri.FirstName = "Ofer";
        //To show two way binding mode
        //lbl.Text = "Ofer";
    }

    
}