using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab7 {
    public partial class MainWindow {
        private int[] array;
        MyMatrix matrix = new MyMatrix();
        Store _store = new Store();

        public MainWindow() {
            InitializeComponent();
            /* searchBy.Items.Add("назвою");
             searchBy.Items.Add("індексом");*/
        }

        private void Is_Randon_Checked(object sender, RoutedEventArgs e) {
            num_elements.IsEnabled = !num_elements.IsEnabled;
            input_array.IsEnabled = !input_array.IsEnabled;
        }

        private void Set_array_OnClick(object sender, RoutedEventArgs e) {
            int count;
            Random random = new Random();
            if (is_Randon.IsChecked == true) {
                try {
                    count = Convert.ToInt32(num_elements.Text);
                    if (count < 0) {
                        throw new Exception("Кількість елементів не може бути від'ємним");
                    }
                    if (count == 0) {
                        throw new Exception("Пустий масив");
                    }
                }
                catch (Exception exception) {
                    MessageBox.Show(exception.Message, "Input error");
                    return;
                }

                array = new int[count];
                for (int i = 0; i < count; i++) {
                    array[i] = random.Next(-50, 50);
                }

                input_array.Text = string.Join(" ", array);
            }
            else {
                try {
                    array = input_array.Text.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                }
                catch (Exception) {
                    MessageBox.Show("Помилка введення");
                    num_elements.Text = "";
                    return;
                }
            }

            max_value.Content = $"Максимальне значення {array.Max()}";
            min_value.Content = $"Мінімальне значення {array.Min()}";
            sum.Content = $"Сума всіх чисел {array.Sum()}";
            avg.Content = $"Середнє значення {array.Average()}";
            neg_vals.Text = $"Непарні числа {string.Join(";", array.Where(x => x % 2 == 1))}";
        }

        private void SetButt_OnClick(object sender, RoutedEventArgs e) {
            try {
                matrix.Colums = Convert.ToInt32(colums.Text);
                matrix.Rows = Convert.ToInt32(rows.Text);
            }
            catch (Exception) {
                MessageBox.Show("Помилка введення");
                return;
            }
            
            outLabel.TabIndex = 4;
            outLabel.Text = matrix.getMatrix();
        }

        private void SearchField_OnMouseEnter(object sender, MouseEventArgs e) {
            string[] data = new string[_store.Articles.Count];

            if (searchBy.SelectedIndex == 0) {
                int i = 0;
                foreach (var article in _store.Articles) {
                    data[i] = article.PoroductName;
                    i++;
                }
            }

            if (searchBy.SelectedIndex == 1) {
                int i = 0;
                foreach (var unused in _store.Articles) {
                    data[i] = i++.ToString();
                }
            }

            try {
                searchField.ItemsSource = data;
            }
            catch (Exception) {
                // ignored
            }
        }

        private void SearchBy_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            editCheckBox.Visibility = Visibility.Visible;
        }

        private void SearchField_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            Article article = _store.Articles[searchField.SelectedIndex];
            nameShowBox.Text = article.PoroductName;
            shopShowBox.Text = article.StoreName;
            costShowBox.Text = article.CostGoods.ToString();
        }

        private void EditCheckBox_OnChecked(object sender, RoutedEventArgs e) {
            if (_store.Articles.Count < 1) {
                editCheckBox.IsChecked = false;
                return;
            }
            nameShowBox.IsEnabled = !nameShowBox.IsEnabled;
            shopShowBox.IsEnabled = !shopShowBox.IsEnabled;
            costShowBox.IsEnabled = !costShowBox.IsEnabled;
            saveChangesButton.Visibility = costShowBox.IsEnabled ? Visibility.Visible : Visibility.Hidden;
        }

        private void SaveChangesButton_OnClick(object sender, RoutedEventArgs e) {
            Article article = _store.Articles[searchField.SelectedIndex];
            try { 
                article.CostGoods = Convert.ToInt32(costShowBox.Text);
            }
            catch (Exception) {
                MessageBox.Show("Помилка введення ціни", "Input error");
            }
            
            article.PoroductName = nameShowBox.Text;
            article.StoreName = shopShowBox.Text;
            saveChangesButton.Visibility = Visibility.Hidden;
            editCheckBox.IsChecked = false;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e) {
            Article article = new Article("", "", 0);
            try {
                article.CostGoods = Convert.ToInt32(costBox.Text);
            }
            catch (Exception) {
                MessageBox.Show("Непвильно введена ціна товару", "Input error");
                costBox.Text = "";
                return;
            }

            article.PoroductName = nameBox.Text;
            article.StoreName = storeBox.Text;
            _store.Articles.Add(article);
            costBox.Text = nameBox.Text = storeBox.Text = "";
        }
    }
}