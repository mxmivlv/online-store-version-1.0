using Module_17.Commands;
using System.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using Module_17.Models;

namespace Module_17.ViewModels
{
    internal class ViewModelMainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ModelMSSql modelMSSql;

        #region Заголовки, label
        public string Title { get { return title; } }
        public string GroupboxTitleClient { get { return groupboxTitleClient; } }
        public string Surname { get { return surname; } }
        public string Name { get { return name; } }
        public string Patronymic { get { return patronymic; } }
        public string NumberPhone { get { return numberPhone; } }
        public string Email { get { return email; } }
        public string GroupboxTitleBuyer { get { return groupboxTitleBuyer; } }
        public string CodeProduct { get { return codeProduct; } }
        public string NameProduct { get { return nameProduct; } }

        private string title = "Онлайн магазин";
        private string groupboxTitleClient = "Работа с клиентами";
        private string surname = "Фамилия:";
        private string name = "Имя:";
        private string patronymic = "Отчество:";
        private string numberPhone = "Номер телефона:";
        private string email = "Почта:";
        private string groupboxTitleBuyer = "Работа с покупками клиентов";
        private string codeProduct = "Код продукта:";
        private string nameProduct = "Название продукта:";
        #endregion

        #region Для работы БД
        public DataTable SqlDataTableClient
        {
            get { return sqlDataTableClient; }
            set
            {
                if (sqlDataTableClient == value)
                    return;
                sqlDataTableClient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SqlDataTableClient)));
            }
        }
        public DataTable SqlDataTablePurchaseClient
        {
            get { return sqlDataTablePurchaseClient; }
            set
            {
                if (sqlDataTablePurchaseClient == value)
                    return;
                sqlDataTablePurchaseClient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SqlDataTablePurchaseClient)));
            }
        }
        public DataRowView CurrentRow
        {
            get { return currentRow; }
            set
            {
                currentRow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentRow)));
            }
        }
        public string TextboxSurname
        {
            get { return textboxSurname; }
            set
            {
                if (textboxSurname == value)
                    return;
                textboxSurname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.textboxSurname)));
            }
        }
        public string TextboxName
        {
            get { return textboxName; }
            set
            {
                if (textboxName == value)
                    return;
                textboxName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.textboxName)));
            }
        }
        public string TextboxPatronymic
        {
            get { return textboxPatronymic; }
            set
            {
                if (textboxPatronymic == value)
                    return;
                textboxPatronymic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.textboxPatronymic)));
            }
        }
        public string TextboxPhoneNumber
        {
            get { return textboxPhoneNumber; }
            set
            {
                if (textboxPhoneNumber == value)
                    return;
                textboxPhoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextboxPhoneNumber)));
            }
        }
        public string TextboxEmail
        {
            get { return textboxEmail; }
            set
            {
                if (textboxEmail == value)
                    return;
                textboxEmail = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.textboxEmail)));
            }
        }
        public string TextboxCodeProduct
        {
            get { return textboxCodeProduct; }
            set
            {
                if (textboxCodeProduct == value)
                    return;
                textboxCodeProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextboxCodeProduct)));
            }
        }
        public string TextboxNameProduct
        {
            get { return textboxNameProduct; }
            set
            {
                if (textboxNameProduct == value)
                    return;
                textboxNameProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextboxNameProduct)));
            }
        }

        private DataTable sqlDataTableClient;
        private DataTable sqlDataTablePurchaseClient;
        private DataRowView currentRow;
        private string textboxSurname;
        private string textboxName;
        private string textboxPatronymic;
        private string textboxPhoneNumber;
        private string textboxEmail;
        private string textboxCodeProduct;
        private string textboxNameProduct;
        #endregion

        #region Команды
        #region Команда добавления клиента
        public ICommand CommandAddClient { get; }
        private void onCommandAddClientExecuted(object p)
        {
            modelMSSql.Insert(TextboxSurname, TextboxName, TextboxPatronymic, TextboxPhoneNumber, TextboxEmail, SqlDataTableClient);

            TextboxSurname = null;
            TextboxName = null;
            TextboxPatronymic = null;
            TextboxPhoneNumber = null;
            TextboxEmail = null;
        }
        private bool commandAddClientExecute(object p)
        {
            return true;
        }
        #endregion

        #region Команда удаления клиента
        public ICommand CommandDeleteClient { get; }
        private void onCommandDeleteClientExecuted(object p)
        {
            modelMSSql.Delete(CurrentRow, SqlDataTableClient);
        }
        private bool commandDeleteClientExecute(object p) => true;
        #endregion

        #region Команда обновления данных
        public ICommand CommandUpdateClient { get; }
        private void onCommandUpdateClientExecuted(object p)
        {
            modelMSSql.Update(SqlDataTableClient);
        }
        private bool commandUpdateClientExecute(object p) => true;
        #endregion

        #region Команда загрузки покупок у данного клиента
        public ICommand CommandLoadPurchaseClient { get; }
        private void onCommandLoadPurchaseClientExecuted(object p)
        {
            modelMSSql.PurchaseClient(CurrentRow, SqlDataTablePurchaseClient);
        }
        private bool commandLoadPurchaseClientExecute(object p) => true;
        #endregion

        #region Команда добавление покупки клиенту
        public ICommand CommandAddBuyer { get; }

        private void onCommandAddBuyerExecuted(object p)
        {
            modelMSSql.AddBuyer(CurrentRow, TextboxCodeProduct, TextboxNameProduct, SqlDataTablePurchaseClient);

            TextboxCodeProduct = null;
            TextboxNameProduct = null;
        }
        private bool commandAddBuyerExecute(object p) => true;
        #endregion
        #endregion

        public ViewModelMainWindow()
        {
            CommandAddClient = new Command(onCommandAddClientExecuted, commandAddClientExecute);
            CommandDeleteClient = new Command(onCommandDeleteClientExecuted, commandDeleteClientExecute);
            CommandUpdateClient = new Command(onCommandUpdateClientExecuted, commandUpdateClientExecute);
            CommandLoadPurchaseClient = new Command(onCommandLoadPurchaseClientExecuted, commandLoadPurchaseClientExecute);
            CommandAddBuyer = new Command(onCommandAddBuyerExecuted, commandAddBuyerExecute);
            modelMSSql = new ModelMSSql();
            SqlDataTableClient = new DataTable();
            SqlDataTablePurchaseClient = new DataTable();
            modelMSSql.Error += modelMSSql.ErrorAsync;
            Application.Current.MainWindow.Closing += new CancelEventHandler(modelMSSql.ClosingAsync);
            modelMSSql.PrintDbSQLServerAsync(SqlDataTableClient, SqlDataTablePurchaseClient);
        }
    }
}
