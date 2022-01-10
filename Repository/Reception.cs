using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Hospital.Service;
using Newtonsoft.Json;
using Hotel_Menegment.Service;
using static System.Console;
using static Hotel_Menegment.Service.MenuHotel;

namespace Hospital
{
    public class Reception 
    {

        #region Ro'yhatdan o"tish va Xona bant qilish
        public static void AddPerson(User user)
        {      
            string json1 = File.ReadAllText(Constants.PatientDbPath);
            IList<User> PersonList = JsonConvert.DeserializeObject<List<User>>(json1);

            bool isAdd = false;
             foreach (User person in PersonList)
            {
                if (person.Email == user.Email || person.Room == user.Room)
                {
                    isAdd = true;
                }
            }
            if (!isAdd)
            {
                PersonList.Add(user);

                string json = JsonConvert.SerializeObject(PersonList);
                File.WriteAllText(Constants.PatientDbPath, json);

                Clear();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("\t\t\tXona band qilindi!\n");
                HotelMenu();
            }
            else
            {
                Clear();
                
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\t\tBu xona bant qilingan yoki bunday Email bor!\n");
                HotelMenu();
            }
        }
        #endregion

        #region Ma'lumotni o'chirish
        public static void DeletePerson(User user)
        {
            try
            {
                string json = File.ReadAllText(Constants.PatientDbPath);
                IList<User> people = JsonConvert.DeserializeObject<List<User>>(json);

                var man = people.Where(p => p.FirstName == user.FirstName &&
                                       p.Email == user.Email).ToList();

                if (man.Count > 0)
                {
                    foreach (var p in man)
                    {
                        people.Remove(p);
                    }

                    string res = JsonConvert.SerializeObject(people);
                    File.WriteAllText(Constants.PatientDbPath, res);


                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nSuccess deleted\n");
                    ForegroundColor = ConsoleColor.White;
                }
            }
            catch
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nAn error occurred.Please try again!\n");
                ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion

        public static ICollection<User> result;

        public static ICollection<User> SearchPerson(string word, int searchchoise)
        {

            string jsoon = File.ReadAllText(Constants.PatientDbPath);
            ICollection<User> SearchResultData = JsonConvert.DeserializeObject<ICollection<User>>(jsoon);

            if (searchchoise == 1)
            {
                result = SearchResultData.Select(x => x).Where(x => x.FirstName.Equals(word)).ToList();
                if (result != null) return result;
                else WriteLine("No such information was found in the database!");
            }
            else if (searchchoise == 2)
            {
                result = SearchResultData.Select(x => x).Where(x => x.LastName.Equals(word)).ToList();


                if (result != null) return result;
                else WriteLine("No such information was found in the database");
            }
            else if (searchchoise == 3)
            {
                result = SearchResultData.Select(x => x).Where(x => x.BirthDay.Equals(word)).ToList();
                if (result != null) return result;
                else WriteLine("No such information was found in the database!");
            }
            else if (searchchoise == 4)
            {
                result = SearchResultData.Select(x => x).Where(x=> x.Room.Equals(word)).ToList();
                if (result != null) return result;
                else WriteLine("No such information was found in the database!");
            }
            else if (searchchoise == 5)
            {
                result = SearchResultData.Select(x => x).Where(x => x.Nationality.Equals(word)).ToList();
                if (result != null) return result;
                else WriteLine("No such information was found in the database!");
            }

            return result;
        }

        #region UpdatePatient
        public static void UpDatePerson(string ism, string email)
        {
            int check = 0;
            string json = File.ReadAllText(Constants.PatientDbPath);
            IList<User> people = JsonConvert.DeserializeObject<List<User>>(json);
            

            bool isExist = false;
            foreach (User user in people)
            {
                if (user.FirstName.Equals(ism) && user.Email.Equals(email))
                {
                    isExist = true;

                    people.Remove(user);
                    break;
                }
            }
            if (!isExist)
            {
                WriteLine("Bunday ma'lumot bazada yo'q!");
                HotelMenu();
            }
            else
            {
                Clear();
                string newJson = JsonConvert.SerializeObject(people);
                File.WriteAllText(Constants.PatientDbPath, newJson);
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

                AddPerson(user);
                WriteLine("\n");

                #endregion
            }




            if (check > 0) WriteLine("Seccessfully replaced!");
            else WriteLine("If the change did not work please try again!");
        }

        #endregion


        #region NumberOfElements
        public static int NumberOfElements()
        {
            string json2 = File.ReadAllText(Constants.PatientDbPath);
            IList<User> rooms = JsonConvert.DeserializeObject<List<User>>(json2);
            int result = rooms.Count;
            return result;
        }
        #endregion


        #region CheckPersonExist
        private static bool CheckPersonExist(string lastname, string brithday)
        {
            string json = File.ReadAllText(Constants.PatientDbPath);
            if (json == null) return false;
            IList<User> dbData = JsonConvert.DeserializeObject<List<User>>(json);
            foreach (User db in dbData)
            {
                if (db.LastName == lastname && db.BirthDay == brithday) return true;

            }
            return false;
        }

        #endregion
    }
}
