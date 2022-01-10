using Hospital.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Hospital.Menu
{
    public static class MainMenu
    {
        public static void Menu()
        {
            while (true)
            {
            Begin:           
                Show();            
                ForegroundColor = ConsoleColor.Green;
                Write("Adminstration[1]\t\t\t\t");

                ForegroundColor = ConsoleColor.Red;
                Write("Dasturdan chiqish [2]\n");

                ForegroundColor = ConsoleColor.Blue;
                Write(">>> ");

                string tanlov = ReadLine();

                if (tanlov == "1")
                {                  
                MainMenu:
                Start:               
                    Clear();
                End:
                    Show();
                    ForegroundColor = ConsoleColor.DarkGreen;
                    Write("Xona bant qilish_[1]\n" +
                          "Qidirish_________[2]\n" +
                          "O'chirish________[3]\n" +
                          "Yangilash________[4]\n" +
                          "Bosh menu________[5]\n" +
                          "Oynani tozalash__[0]\n");

                    ForegroundColor = ConsoleColor.Gray;
                    Write(">>> ");
                    string choise = ReadLine();
                    if (choise == "1")
                    {
                        #region Ro'yxatdan o'tish va Xona bant qilish
                        Clear();
                        Show();
                        User user = new User();

                        Write("Ismingizni kiriting: ");
                        user.FirstName = ReadLine();
                        Write("Sharfingizni kiriting: ");
                        user.LastName = ReadLine();
                        Write("Tug'ulgan yilingizni kiriting [kun/oy/yil] : ");
                        user.BirthDay = ReadLine();
                        Write("Emailni kiriting: ");
                        user.Email = ReadLine();
                        Write("Bino manzilini kiriting: ");
                        user.Nationality = ReadLine();
                        Write("Xona raqamini kiriting: ");
                        user.Room = ReadLine();

                        Reception.AddPerson(user);
                        WriteLine("\n");
                        goto MainMenu;
                        #endregion
                    }

                    else if (choise == "2")
                    {
                        #region Foydalanuvchini qidirish
                        Clear();
                        Show();
                        WriteLine("Ism bilan qidirish_____[1]\n" +
                                  "Sharif bilan qidirish__[2]\n" +
                                  "Tug'ilgan sana bilan___[3]\n\n" +
                                  "Xona raqami bilan______[4]\n" +
                                  "Bino manzili bilan_____[5]\n");

                        int searchchoise = int.Parse(ReadLine());
                        Write("Enter the word : ");
                        string word = ReadLine();

                        ICollection<User> result = Reception.SearchPerson(word, searchchoise);
                        WriteLine("*****************************************************************************************************************************");
                        foreach (User person in result)
                        {
                            WriteLine($"Name :{person.FirstName}\n" +
                                      $"Last name: {person.LastName}\n" +
                                      $"Birthday : {person.BirthDay}\n" +
                                      $"Room number {person.Room}\n" +
                                      $"Email: {person.Email}\n" +
                                      $"State: {person.Nationality}*******************************************");
                        }

                        WriteLine("\n");
                        goto MainMenu;
                        #endregion

                    }
                   
                    else if (choise == "3")
                    {
                        #region Malumotlarni o'chirish
                        Clear();
                        Show();
                        User user = new User();

                        Write("Ismingizni kiriting: ");
                        user.FirstName = ReadLine();
                        Write("Emailni kiriting: ");
                        user.Email = ReadLine();

                        Reception.DeletePerson(user);
                        Clear();
                        ForegroundColor = ConsoleColor.Magenta;
                        WriteLine("Malumotlar o'chirildi!");
                        
                        goto MainMenu;
                        #endregion
                    }


                    else if (choise == "4")
                    {
                        #region  Ma'lumotlarni yangilash
                        Clear();
                        Show();
                        Write("Ismingizni kiriting: ");
                        string ism = ReadLine();
                        Write("Emailni kiriting: ");
                        string email = ReadLine();

                        Reception.UpDatePerson(ism, email);
                        WriteLine("\n");
                        

                        #endregion

                    }
                    else if (choise == "5")
                    {
                        Clear();
                        goto Begin;
                    }
                    else if (choise == "0") 
                    {
                        Clear();
                        goto Start;
                    }
                    else
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("\t\tXato kirittingiz! Iltimos qayta urinig\n");
                        goto End;
                    }
                }
                else if (tanlov == "2")
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Xizmatimizdan foydalanganingiz uchun katta rahmat!");
                    break;
                }
                else
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\tXato kirittingiz! Iltimos qayta urinig [1] yoki [2]\n");
                }

            }
        }

            public static void Show() 
            {
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("\t\t\tHotel Management\n");
        }
    }
}