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
            //_members = new()
            //{
            //    //Create DataGrid Items Info
            //    new Member { Number = "1", Character = "I", BgColor = converter.ConvertFromString("#1098ad") as Brush, Name = "Иван Иванов", Position = "Менеджер", Email = "ivanov@name.com", Phone = "123-456" },
            //    new Member { Number = "2", Character = "P", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Петров", Position = "Глава департамента", Email = "petrov@name.com", Phone = "234-567" },
            //    new Member { Number = "3", Character = "S", BgColor = converter.ConvertFromString("#50f8f7") as Brush, Name = "Антон Сидоров", Position = "Директор", Email = "sidorov@name.com", Phone = "345-678" },
            //    new Member { Number = "4", Character = "N", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Владимир Набоков", Position = "Менеджер", Email = "nabokov@name.com", Phone = "456-789" },
            //    new Member { Number = "5", Character = "P", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Александр Пушкин", Position = "Инженер", Email = "pushkin@name.com", Phone = "567-890" },
            //    new Member { Number = "6", Character = "G", BgColor = converter.ConvertFromString("#6741d9") as Brush, Name = "Александр Грибоедов", Position = "Программист", Email = "griboedov@name.com", Phone = "987-654" },
            //    new Member { Number = "7", Character = "N", BgColor = converter.ConvertFromString("#ff6d00") as Brush, Name = "Александр Невский", Position = "Дизайнер", Email = "nevski@name.com", Phone = "876-543" },
            //    new Member { Number = "8", Character = "G", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Иван Грозный", Position = "Секретарь", Email = "grozny@name.com", Phone = "765-432" },
            //    new Member { Number = "9", Character = "R", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Романов", Position = "Юрист", Email = "romanov@name.com", Phone = "654-321" },
            //    new Member { Number = "10", Character = "L", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Владимир Ленин", Position = "Всегда живой", Email = "lenin@name.com", Phone = "666-666" },
            //    new Member { Number = "1", Character = "J", BgColor = converter.ConvertFromString("#1098ad") as Brush, Name = "Иван Иванов", Position = "Менеджер", Email = "ivanov@name.com", Phone = "123-456" },
            //    new Member { Number = "2", Character = "K", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Петров", Position = "Глава департамента", Email = "petrov@name.com", Phone = "234-567" },
            //    new Member { Number = "3", Character = "M", BgColor = converter.ConvertFromString("#dff8f0") as Brush, Name = "Антон Сидоров", Position = "Директор", Email = "sidorov@name.com", Phone = "345-678" },
            //    new Member { Number = "4", Character = "N", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Владимир Набоков", Position = "Менеджер", Email = "nabokov@name.com", Phone = "456-789" },
            //    new Member { Number = "5", Character = "T", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Александр Пушкин", Position = "Инженер", Email = "pushkin@name.com", Phone = "567-890" },
            //    new Member { Number = "6", Character = "L", BgColor = converter.ConvertFromString("#6741d9") as Brush, Name = "Александр Грибоедов", Position = "Программист", Email = "griboedov@name.com", Phone = "987-654" },
            //    new Member { Number = "7", Character = "R", BgColor = converter.ConvertFromString("#ff6d00") as Brush, Name = "Александр Невский", Position = "Дизайнер", Email = "nevski@name.com", Phone = "876-543" },
            //    new Member { Number = "8", Character = "D", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Иван Грозный", Position = "Секретарь", Email = "grozny@name.com", Phone = "765-432" },
            //    new Member { Number = "9", Character = "G", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Романов", Position = "Юрист", Email = "romanov@name.com", Phone = "654-321" },
            //    new Member { Number = "10", Character = "V", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Владимир Ленин", Position = "Всегда живой", Email = "lenin@name.com", Phone = "666-666" },
            //    new Member { Number = "1", Character = "J", BgColor = converter.ConvertFromString("#1098ad") as Brush, Name = "Иван Иванов", Position = "Менеджер", Email = "ivanov@name.com", Phone = "123-456" },
            //    new Member { Number = "2", Character = "K", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Петров", Position = "Глава департамента", Email = "petrov@name.com", Phone = "234-567" },
            //    new Member { Number = "3", Character = "M", BgColor = converter.ConvertFromString("#dff8f0") as Brush, Name = "Антон Сидоров", Position = "Директор", Email = "sidorov@name.com", Phone = "345-678" },
            //    new Member { Number = "4", Character = "N", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Владимир Набоков", Position = "Менеджер", Email = "nabokov@name.com", Phone = "456-789" },
            //    new Member { Number = "5", Character = "T", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Александр Пушкин", Position = "Инженер", Email = "pushkin@name.com", Phone = "567-890" },
            //    new Member { Number = "6", Character = "L", BgColor = converter.ConvertFromString("#6741d9") as Brush, Name = "Александр Грибоедов", Position = "Программист", Email = "griboedov@name.com", Phone = "987-654" },
            //    new Member { Number = "7", Character = "R", BgColor = converter.ConvertFromString("#ff6d00") as Brush, Name = "Александр Невский", Position = "Дизайнер", Email = "nevski@name.com", Phone = "876-543" },
            //    new Member { Number = "8", Character = "D", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Иван Грозный", Position = "Секретарь", Email = "grozny@name.com", Phone = "765-432" },
            //    new Member { Number = "9", Character = "G", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Романов", Position = "Юрист", Email = "romanov@name.com", Phone = "654-321" },
            //    new Member { Number = "10", Character = "V", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Владимир Ленин", Position = "Всегда живой", Email = "lenin@name.com", Phone = "666-666" }
            //};
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