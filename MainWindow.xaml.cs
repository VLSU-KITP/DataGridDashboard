using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace DataGridDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Member> _members = new();

        public MainWindow()
        {
            InitializeComponent();

            var converter = new BrushConverter();
            LoadMembers();
            membersDataGrid.ItemsSource = _members;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(membersDataGrid.ItemsSource);
            view.Filter = UserFilter;
            ToEmployees_Click(ButtonEmployees, new RoutedEventArgs());
        }

        private readonly string _path = "../../../Employees.json";

        private void LoadMembers()
        {
            try
            {
                string json = File.ReadAllText(_path);
                var members = JsonConvert.DeserializeObject<ObservableCollection<Member>>(json);
                if (members != null)
                {
                    _members = members;
                }
            }
            catch
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Не удалось открыть файл с данными о сотрудниках.");
                customMessageBox.ShowDialog();
            }
        }

        private bool needToSave = false;

        private void SaveChanges()
        {
            CustomMessageBox cmBox = new CustomMessageBox("Вы хотите сохранить изменения?", true) { Owner = this };
            if (cmBox.ShowDialog() == false)
                return;

            try
            {
                string json = JsonConvert.SerializeObject(_members, Formatting.Indented);
                using StreamWriter file = new(_path);
                file.Write(json);
            }
            catch
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Не удалось сохранить изменения.");
                customMessageBox.ShowDialog();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (this.IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        Random random = new Random();

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            WindowNewEmployee window = new WindowNewEmployee() { Owner = this };
            Member member = new();
            window.DataContext = member;
            if (window.ShowDialog() == true)
            {
                Color? color = window.Color_Picker.SelectedColor;
                if (color != null)
                {
                    member.BgColor = new SolidColorBrush(color.Value);

                }
                else
                {
                    member.BgColor = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                }
                _members.Add(member);
                needToSave = true;
            }
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                WindowNewEmployee window = new WindowNewEmployee() { Owner = this };
                Member member = button.DataContext as Member;
                Member memberCopy = member.Copy();
                window.DataContext = memberCopy;
                window.Color_Picker.SelectedColor = ((SolidColorBrush)memberCopy.BgColor).Color;
                if (window.ShowDialog() == true)
                {
                    Color? color = window.Color_Picker.SelectedColor;
                    if (color != null)
                    {
                        member.BgColor = new SolidColorBrush(color.Value);
                    }
                    else
                    {
                        member.BgColor = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                    }
                    member.Number = memberCopy.Number;
                    member.Name = memberCopy.Name;
                    member.Character = memberCopy.Character;
                    member.Email = memberCopy.Email;
                    member.Phone = memberCopy.Phone;
                    needToSave = true;
                }
            }
        }


        private void RemoveEmployee(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Удалить выбранного сотрудника?", true);
                if (customMessageBox.ShowDialog() == true)
                {
                    Member member = button.DataContext as Member;
                    _members.Remove(member);
                    needToSave = true;
                }
            }
        }


        private void ToMessages_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                EnableButtons();
                HideGrids();
                button.IsEnabled = false;
                mainGridMessages.Visibility = Visibility.Visible;
            }
        }

        private void ToBudget_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                EnableButtons();
                HideGrids();
                button.IsEnabled = false;
                mainGridBudget.Visibility = Visibility.Visible;
            }
        }

        private void ToEmployees_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                EnableButtons();
                HideGrids();
                button.IsEnabled = false;
                mainGridEmployee.Visibility = Visibility.Visible;
            }
        }

        private void ToEvents_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                EnableButtons();
                HideGrids();
                button.IsEnabled = false;
                mainGridEvents.Visibility = Visibility.Visible;
            }
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                EnableButtons();
                HideGrids();
                button.IsEnabled = false;
                mainGridMain.Visibility = Visibility.Visible;
            }
        }

        private void EnableButtons()
        {
            ButtonMain.IsEnabled = true;
            ButtonBudget.IsEnabled = true;
            ButtonEvents.IsEnabled = true;
            ButtonEmployees.IsEnabled = true;
            ButtonMessages.IsEnabled = true;
        }

        private void HideGrids()
        {
            mainGridMain.Visibility = Visibility.Hidden;
            mainGridEmployee.Visibility = Visibility.Hidden;
            mainGridMessages.Visibility = Visibility.Hidden;
            mainGridEvents.Visibility = Visibility.Hidden;
            mainGridBudget.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (needToSave)
                SaveChanges();
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (item as Member).Name.Contains(txtFilter.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(membersDataGrid.ItemsSource).Refresh();
        }
    }

    public class Member : INotifyPropertyChanged
    {
        private string? _character;
        public string? Character
        {
            get
            {
                return _character;
            }
            set
            {
                _character = value;
                OnPropertyChanged(nameof(Character));
            }
        }

        private string? _number;
        public string? Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private string? _name;
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string? _position;
        public string? Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        private string? _email;
        public string? Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string? _phone;
        public string? Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private Brush? _bgColor;
        public Brush? BgColor
        {
            get
            {
                return _bgColor;
            }
            set
            {
                _bgColor = value;
                OnPropertyChanged(nameof(BgColor));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Member Copy()
        {
            return new Member
            {
                Character = Character,
                Number = Number,
                Name = Name,
                Position = Position,
                Email = Email,
                Phone = Phone,
                BgColor = BgColor
            };
        }
    }
}