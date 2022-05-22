using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using Notifications.Wpf.Core;

namespace Module_17.Models
{
    public class ModelMSSql
    {
        public event Action<string> Error;
        private SqlConnectionStringBuilder sqlConnectionStringBuilder;
        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        public DataRow dataRow;
        private NotificationManager notificationManager = new NotificationManager();

        /// <summary>
        /// Метод вывода данных в форму
        /// </summary>
        /// <param name="sqlDataTableClient">Бд клиентов</param>
        /// <param name="sqlDataTablePurchaseClient">Бд покупок клиентов</param>
        public async void PrintDbSQLServerAsync(DataTable sqlDataTableClient, DataTable sqlDataTablePurchaseClient)
        {
            try
            {
                await Task.Run(() =>
                {
                    sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
                    {
                        DataSource = @"(localdb)\MSSQLLocalDB",
                        InitialCatalog = "MSSQLShop",
                        IntegratedSecurity = true,
                        Pooling = true,
                    };
                    sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                    sqlConnection.Open();
                    sqlDataAdapter = new SqlDataAdapter();


                    var sql = @"SELECT * FROM Client";
                    sqlDataAdapter.SelectCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.Fill(sqlDataTableClient);

                    sql = @"SELECT * FROM PurchaseClient";
                    sqlDataAdapter.SelectCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.Fill(sqlDataTablePurchaseClient);
                });
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Метод добавления клиента
        /// </summary>
        /// <param name="surnameClient">Фамилия клиента</param>
        /// <param name="nameClient">Имя клиента</param>
        /// <param name="patronymicClient">Отчество клиента</param>
        /// <param name="numberPhoneClient">Номер телефона клиента</param>
        /// <param name="emailClient">Почта клиента</param>
        /// <param name="sqlDataTableClient">Бд в которую добавляем клиента</param>
        public void Insert(string surnameClient, string nameClient, string patronymicClient, string numberPhoneClient, string emailClient, DataTable sqlDataTableClient)
        {
            try
            {
                // Проверка на пустые строки
                if (surnameClient != null && nameClient != null && patronymicClient != null && emailClient != null)
                {
                    //Формируем новоу строку
                    DataRow dataRow = sqlDataTableClient.NewRow();

                    //Если номер телефона не пустой
                    if (numberPhoneClient != null)
                    {
                        long tempPhone;
                        bool flagTempPhone = long.TryParse(numberPhoneClient, out tempPhone);

                        char[] tempArrayNumberPhone = new char[11];
                        char[] lenghtNumberPhone = numberPhoneClient.ToString().ToCharArray();

                        //Если номер телефона соотвествует длинне и конвертации
                        if (lenghtNumberPhone.Length == tempArrayNumberPhone.Length && flagTempPhone)
                        {
                            dataRow["NumberPhoneClient"] = numberPhoneClient;
                        }
                        else
                        {
                            Error?.Invoke($"Не верный номер телефона");
                            return;
                        }
                    }
                    else
                    {
                        dataRow["NumberPhoneClient"] = 0;
                    }
                    //Запрос на добавление клиента
                    var sql = @"INSERT INTO Client (SurnameClient, NameClient, PatronymicClient, NumberPhoneClient, EmailClient) 
                                VALUES (@SurnameClient, @NameClient, @PatronymicClient, @NumberPhoneClient, @EmailClient);
                                SET @Id = @@IDENTITY;";

                    //Выполняем запрос
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);

                    //В параметрах адаптера и запроса приравниваем к переменным запроса значения, которое указали в экземпляре сроки
                    sqlDataAdapter.InsertCommand.Parameters.Add("Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
                    sqlDataAdapter.InsertCommand.Parameters.Add("@SurnameClient", SqlDbType.NVarChar, 50, "SurnameClient");
                    sqlDataAdapter.InsertCommand.Parameters.Add("@NameClient", SqlDbType.NVarChar, 50, "NameClient");
                    sqlDataAdapter.InsertCommand.Parameters.Add("@PatronymicClient", SqlDbType.NVarChar, 50, "PatronymicClient");
                    sqlDataAdapter.InsertCommand.Parameters.Add("@NumberPhoneClient", SqlDbType.BigInt, 11, "NumberPhoneClient");
                    sqlDataAdapter.InsertCommand.Parameters.Add("@EmailClient", SqlDbType.NVarChar, 50, "EmailClient");

                    //Добавляем остальные значения в строку
                    dataRow["SurnameClient"] = surnameClient;
                    dataRow["NameClient"] = nameClient;
                    dataRow["PatronymicClient"] = patronymicClient;

                    dataRow["EmailClient"] = emailClient;

                    //Добавляем ее в бд
                    sqlDataTableClient.Rows.Add(dataRow);
                    //Обновление таблицы
                    sqlDataAdapter.Update(sqlDataTableClient);
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Метод удаления клиента
        /// </summary>
        /// <param name="dataRowView">Выделенная строка с клиентов</param>
        /// <param name="sqlDataTableClient">Бд для удаления</param>
        public void Delete(DataRowView dataRowView, DataTable sqlDataTableClient)
        {
            try
            {
                if (dataRowView != null)
                {
                    var sql = @"DELETE FROM Client WHERE Id = @Id";

                    sqlDataAdapter.DeleteCommand = new SqlCommand(sql, sqlConnection);

                    sqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");

                    dataRowView.Row.Delete();

                    sqlDataAdapter.Update(sqlDataTableClient);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Метод обновления данных
        /// </summary>
        /// <param name="sqlDataTableClient">Бд для обновления</param>
        public void Update(DataTable sqlDataTableClient)
        {
            try
            {
                //Запрос на редактирование данных в таблице
                var sql = @"UPDATE Client SET SurnameClient = @SurnameClient,  
                                          NameClient = @NameClient, 
                                          PatronymicClient = @PatronymicClient, 
                                          NumberPhoneClient = @NumberPhoneClient, 
                                          EmailClient = @EmailClient
                                       WHERE Id = @Id";

                sqlDataAdapter.UpdateCommand = new SqlCommand(sql, sqlConnection);

                sqlDataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").SourceVersion = DataRowVersion.Original;
                sqlDataAdapter.UpdateCommand.Parameters.Add("@SurnameClient", SqlDbType.NVarChar, 50, "SurnameClient");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@NameClient", SqlDbType.NVarChar, 50, "NameClient");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@PatronymicClient", SqlDbType.NVarChar, 50, "PatronymicClient");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@NumberPhoneClient", SqlDbType.BigInt, 11, "NumberPhoneClient");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@EmailClient", SqlDbType.NVarChar, 50, "EmailClient");

                //Обновляем таблицу
                sqlDataAdapter.Update(sqlDataTableClient);
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Вывод покупок у выделенного клиента
        /// </summary>
        /// <param name="dataRowView">Выделенный клиент</param>
        /// <param name="sqlDataTablePurchaseClient">Бд покупок</param>
        public void PurchaseClient(DataRowView dataRowView, DataTable sqlDataTablePurchaseClient)
        {
            try
            {
                if (dataRowView != null)
                {
                    sqlDataTablePurchaseClient.Clear();

                    string tempEmail = Convert.ToString(dataRowView.Row["EmailClient"]);

                    var sql = $@"SELECT * FROM PurchaseClient WHERE EmailBuyer = '{tempEmail}'";

                    sqlDataAdapter.SelectCommand = new SqlCommand(sql, sqlConnection);

                    sqlDataAdapter.Fill(sqlDataTablePurchaseClient);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Метод добавления покупок к клиенту
        /// </summary>
        /// <param name="dataRowView">Выделенный клиент к которому нужно добавить покупку</param>
        /// <param name="codeProduct">Код продукта</param>
        /// <param name="nameProduct">Наименование продукта</param>
        /// <param name="sqlDataTablePurchaseClient">Бд покупок</param>
        public void AddBuyer(DataRowView dataRowView, string codeProduct, string nameProduct, DataTable sqlDataTablePurchaseClient)
        {
            try
            {
                if (dataRowView != null && codeProduct != null && nameProduct != null)
                {
                    string tempEmail = Convert.ToString(dataRowView.Row["EmailClient"]);
                    int tempCodeProduct = Convert.ToInt32(codeProduct);
                    string tempNameProduct = Convert.ToString(nameProduct);

                    var sql = @"INSERT INTO PurchaseClient (EmailBuyer, CodeProduct, NameProduct) 
                                            VALUES (@EmailBuyer, @CodeProduct, @NameProduct);
                                            SET @Id = @@IDENTITY;";

                    //Для того, чтоб обновилась таблица и данные сразу добавились, нужно создать экземпляр сроки. Данным названия столбцов присваеваем значения
                    DataRow dataRow = sqlDataTablePurchaseClient.NewRow();
                    dataRow["EmailBuyer"] = tempEmail;
                    dataRow["CodeProduct"] = tempCodeProduct;
                    dataRow["NameProduct"] = tempNameProduct;

                    //В экземпляр таблицы, строки, добавляем экзмепляр строки
                    sqlDataTablePurchaseClient.Rows.Add(dataRow);

                    //Выполняем запрос
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);

                    //В параметрах адаптера и запроса приравниваем к переменным запроса значения, которое указали в экземпляре сроки
                    sqlDataAdapter.InsertCommand.Parameters.Add("Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
                    sqlDataAdapter.InsertCommand.Parameters.Add("@EmailBuyer", SqlDbType.NVarChar, 50, "EmailBuyer");
                    sqlDataAdapter.InsertCommand.Parameters.Add("@CodeProduct", SqlDbType.BigInt, 50, "CodeProduct");
                    sqlDataAdapter.InsertCommand.Parameters.Add("@NameProduct", SqlDbType.NVarChar, 50, "NameProduct");

                    //Обновление таблицы
                    sqlDataAdapter.Update(sqlDataTablePurchaseClient);
                }
                else
                {
                    Error?.Invoke($"Поля не заполнены");
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke($"{ex.Message}");
            }
        }

        /// <summary>
        /// Метод ошибки
        /// </summary>
        /// <param name="text">Текст ошибки</param>
        public async void ErrorAsync(string text)
        {
            await Task.Run(() => notificationManager.ShowAsync(new NotificationContent
            {
                Title = $"Ошибка",
                Message = $"{text}",
                Type = NotificationType.Error
            }));
        }

        /// <summary>
        /// Метод закрытия подключения к бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ClosingAsync(object sender, CancelEventArgs e)
        {
            await Task.Run(() => sqlConnection.Close());
        }
    }
}
