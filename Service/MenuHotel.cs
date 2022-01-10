using Hospital;
using static Hospital.Menu.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Hotel_Menegment.Service
{
    internal static class MenuHotel
    {
        public static void HotelMenu()
        {
        MainMenu:
            Show();
                    ForegroundColor = ConsoleColor.DarkGreen;
                    Write("Xona bant qilish [1]\n" +
                          "Qidirish         [2]\n" +
                          "O'chirish        [3]\n" +
                          "Yangilash        [4]\n" +
                          "Bosh menu        [5]\n" +
                          "Oynani tozalash  [0]\n");

                    ForegroundColor = ConsoleColor.Gray;
                    Write(">>> ");
                    string choise = ReadLine();
                    if (choise == "1")
                    {

                        #region AddPerson
                        Clear();
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
                        
                        #endregion

                    }
                    else if (choise == "2")
                    {
                        #region PersonSearch
                        Clear();
                       
                        WriteLine("Search by name >>>>[1]\n\nSearch by last name >>>>[2]\n\nSearch by date of birth [3]\n\n" +
                            "Search by room number >>>>[4]\n\nSearch by state >>>>[5]\n>>>>>");
                        int searchchoise = int.Parse(ReadLine());
                        Write("Enter the word : ");
                        string word = ReadLine();

                        ICollection<User> result = Reception.SearchPerson(word, searchchoise);
                        WriteLine("*****************************************************************************************************************************");
                        foreach (User person in result)
                        {
                            WriteLine($"Name :{person.FirstName}\nLast name: {person.LastName}\n" +
                                $"Birthday : {person.BirthDay}\nRoom number {person.Room}\nEmail: {person.Email}\nState: {person.Nationality}*******************************************");
                        }

                        WriteLine("\n");
                      
                        #endregion

                    }

            else if (choise == "3")
            {
                #region PersonDelete
                Clear();
                Show();
                WriteLine();
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
                goto MainMenu;

                #endregion

            }
            else if (choise == "5")
                    {
                        Clear();
                Menu();
                    }
                    else if (choise == "0")
                    {
                        Clear();
                HotelMenu();
                        
                    }
                    else
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("\t\tXato kirittingiz! Iltimos qayta urinig\n");
                        
                    }
                }
               

  
    }
}
