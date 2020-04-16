using System;
using System.Data;
using System.Data.SqlClient;

namespace HW_14_04
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Person sss = new Person();
            
        }
    }

    class Person{
        public const string connectString = "Data Source=localhost;Initial Catalog=Liblary;Integrated Security=True";

        public string firstName{get;set;}
        public string lastName{get;set;}
        public string middleName{get;set;}
        public string birthDay{get;set;}
        public int idUser{get;set;}
        

        public Person(){
            registerNewUser();
        }
        

        public void registerNewUser(){
            bool t = true;
            while (t)
            {
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine("Здравстуйте!!!");
                System.Console.Write("Выберите действие: \n1.Добавить ползователя\n2.Показат информацию\n3.Показать всех ползователей\n4.Удалить ползователья\n5.Изменить данных\n6.Выход\n::");
                int x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                    System.Console.Write("Имя: ");
                    firstName = Console.ReadLine();
                    System.Console.Write("Фамилия: ");
                    lastName = Console.ReadLine();
                    System.Console.Write("Отчества: ");
                    middleName = Console.ReadLine();
                    System.Console.Write("День Рождение: ");
                    birthDay = Console.ReadLine();
                    if(!string.IsNullOrEmpty(firstName)&&!string.IsNullOrEmpty(lastName)&&!string.IsNullOrEmpty(birthDay)){
                        AddUser(connectString,firstName,lastName,middleName,birthDay);
                        System.Console.WriteLine("Uspeshno");
                        t = false;
                        
                    }else{
                        System.Console.WriteLine();
                        System.Console.WriteLine("Ошыбка данных\n");
                        System.Console.WriteLine();
                    }
                    break;

                    case 2:
                    System.Console.Write("Введите id для показ информации: ");
                    int x1 = int.Parse(Console.ReadLine());
                    getInfo(x1);
                    break;

                    case 3:
                    getInfo();
                    break;

                    case 4:
                    System.Console.Write("Введите id для удаление: ");
                    int d = int.Parse(Console.ReadLine());
                    deleteUser(d);
                    break;

                    

                    case 6:
                    t= false;
                    break;
                    
                    default:
                    System.Console.WriteLine("Неверное действие!");
                    break;
                }
            }
        }


        



        

        public void getInfo(int idUser) {
            
            string sql = $"Select * From Person where id={idUser}";
            SqlConnection mssql = new SqlConnection(connectString);
            mssql.Open();
            using (SqlCommand cmd = new SqlCommand(sql, mssql))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    System.Console.WriteLine("Имя: "+dr.GetValue(1));
                    System.Console.WriteLine("Фамилия: "+dr.GetValue(2));
                    System.Console.WriteLine("Отчества: "+dr.GetValue(3));
                    System.Console.WriteLine("День рождение: "+dr.GetValue(4));
                }
            }
            
        }
        public void getInfo(){
            string sql = $"select * from Person";
            SqlConnection mssql = new SqlConnection(connectString);
            mssql.Open();
            using (SqlCommand cmd = new SqlCommand(sql, mssql))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                System.Console.Write(dr.GetName(0)+"\t");
                System.Console.Write(dr.GetName(1)+"\t");
                System.Console.Write(dr.GetName(2)+"\t");
                System.Console.Write(dr.GetName(3)+"\t");
                System.Console.WriteLine(dr.GetName(4)+"\t");
                while (dr.Read())
                {
                    System.Console.Write(dr.GetValue(0)+"\t");
                    System.Console.Write(dr.GetValue(1)+"\t"+"\t");
                    System.Console.Write(dr.GetValue(2)+"\t"+"\t");
                    System.Console.Write(dr.GetValue(3)+"\t"+"\t");
                    System.Console.WriteLine(dr.GetValue(4));
                }
            }
        }

        public void deleteUser(int id){
            string sql = $"Delete from Person where Id={id}";
            SqlConnection mssql = new SqlConnection(connectString);
            mssql.Open();
            using (SqlCommand cmd = new SqlCommand(sql,mssql))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Console.WriteLine();
                    Exception error = new Exception("Failed!", ex);
                    throw error;
 
                }
            }
        }



    }
}
