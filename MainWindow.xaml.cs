using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace DataGridDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var converter = new BrushConverter();
            ObservableCollection<Member> members = new()
            {
                //Create DataGrid Items Info
                new Member { Number = "1", Character = "J", BgColor = converter.ConvertFromString("#1098ad") as Brush, Name = "Иван Иванов", Position = "Менеджер", Email = "ivanov@name.com", Phone = "123-456" },
                new Member { Number = "2", Character = "K", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Петров", Position = "Глава департамента", Email = "petrov@name.com", Phone = "234-567" },
                new Member { Number = "3", Character = "M", BgColor = converter.ConvertFromString("#dff8f0") as Brush, Name = "Антон Сидоров", Position = "Директор", Email = "sidorov@name.com", Phone = "345-678" },
                new Member { Number = "4", Character = "N", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Владимир Набоков", Position = "Менеджер", Email = "nabokov@name.com", Phone = "456-789" },
                new Member { Number = "5", Character = "T", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Александр Пушкин", Position = "Инженер", Email = "pushkin@name.com", Phone = "567-890" },
                new Member { Number = "6", Character = "L", BgColor = converter.ConvertFromString("#6741d9") as Brush, Name = "Александр Грибоедов", Position = "Программист", Email = "griboedov@name.com", Phone = "987-654" },
                new Member { Number = "7", Character = "R", BgColor = converter.ConvertFromString("#ff6d00") as Brush, Name = "Александр Невский", Position = "Дизайнер", Email = "nevski@name.com", Phone = "876-543" },
                new Member { Number = "8", Character = "D", BgColor = converter.ConvertFromString("#ff5252") as Brush, Name = "Иван Грозный", Position = "Секретарь", Email = "grozny@name.com", Phone = "765-432" },
                new Member { Number = "9", Character = "G", BgColor = converter.ConvertFromString("#1e88e5") as Brush, Name = "Петр Романов", Position = "Юрист", Email = "romanov@name.com", Phone = "654-321" },
                new Member { Number = "10", Character = "V", BgColor = converter.ConvertFromString("#0ca678") as Brush, Name = "Владимир Ленин", Position = "Всегда живой", Email = "lenin@name.com", Phone = "666-666" },
                new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Иван Иванов", Position = "Менеджер", Email = "ivanov@name.com", Phone = "123-456" },
                new Member { Number = "2", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Петр Петров", Position = "Глава департамента", Email = "petrov@name.com", Phone = "234-567" },
                new Member { Number = "3", Character = "M", BgColor = (Brush)converter.ConvertFromString("#dff8f0"), Name = "Антон Сидоров", Position = "Директор", Email = "sidorov@name.com", Phone = "345-678" },
                new Member { Number = "4", Character = "N", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Владимир Набоков", Position = "Менеджер", Email = "nabokov@name.com", Phone = "456-789" },
                new Member { Number = "5", Character = "T", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Александр Пушкин", Position = "Инженер", Email = "pushkin@name.com", Phone = "567-890" },
                new Member { Number = "6", Character = "L", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Александр Грибоедов", Position = "Программист", Email = "griboedov@name.com", Phone = "987-654" },
                new Member { Number = "7", Character = "R", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Александр Невский", Position = "Дизайнер", Email = "nevski@name.com", Phone = "876-543" },
                new Member { Number = "8", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Иван Грозный", Position = "Секретарь", Email = "grozny@name.com", Phone = "765-432" },
                new Member { Number = "9", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Петр Романов", Position = "Юрист", Email = "romanov@name.com", Phone = "654-321" },
                new Member { Number = "10", Character = "V", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Владимир Ленин", Position = "Всегда живой", Email = "lenin@name.com", Phone = "666-666" },
                new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Иван Иванов", Position = "Менеджер", Email = "ivanov@name.com", Phone = "123-456" },
                new Member { Number = "2", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Петр Петров", Position = "Глава департамента", Email = "petrov@name.com", Phone = "234-567" },
                new Member { Number = "3", Character = "M", BgColor = (Brush)converter.ConvertFromString("#dff8f0"), Name = "Антон Сидоров", Position = "Директор", Email = "sidorov@name.com", Phone = "345-678" },
                new Member { Number = "4", Character = "N", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Владимир Набоков", Position = "Менеджер", Email = "nabokov@name.com", Phone = "456-789" },
                new Member { Number = "5", Character = "T", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Александр Пушкин", Position = "Инженер", Email = "pushkin@name.com", Phone = "567-890" },
                new Member { Number = "6", Character = "L", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Александр Грибоедов", Position = "Программист", Email = "griboedov@name.com", Phone = "987-654" },
                new Member { Number = "7", Character = "R", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Александр Невский", Position = "Дизайнер", Email = "nevski@name.com", Phone = "876-543" },
                new Member { Number = "8", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Иван Грозный", Position = "Секретарь", Email = "grozny@name.com", Phone = "765-432" },
                new Member { Number = "9", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Петр Романов", Position = "Юрист", Email = "romanov@name.com", Phone = "654-321" },
                new Member { Number = "10", Character = "V", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Владимир Ленин", Position = "Всегда живой", Email = "lenin@name.com", Phone = "666-666" }
            };
        
            membersDataGrid.ItemsSource=members;
        
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
                    IsMaximized = true;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = false;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class Member
    {
        public string? Character { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Brush? BgColor { get; set; }

    }
}