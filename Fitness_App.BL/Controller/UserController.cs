using Fitness_App.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness_App.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {

        /// <summary>
        /// Список пользователей
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Новый ли пользователь
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не должно быть пустым", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список  пользователей
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
            
        }
        /// <summary>
        /// Создание нового User 
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Проверка

            CurrentUser.Gender =new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }


        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public  void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }            
        }
       
    }
}
