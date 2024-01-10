﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public class Personnel
    {
        public struct Employee
        {
            public string Name;
            public string HomePhone;
            public string MobilePhone;
            public DateTime Birthday;
            public DateTime HiringDate;

            public Employee(string Name, string HomePhone, string MobilePhone, DateTime Birthday, DateTime HiringDate)
            {
                this.Name = Name;
                this.HomePhone = HomePhone;
                this.MobilePhone = MobilePhone;
                this.Birthday = Birthday;
                this.HiringDate = HiringDate;
            }
        }

        /* 
         *  Προδιαγραφές ονοματεπώνυμου (Name):
         *  
         *  [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά
         *  [2] Ξεχωρίζουμε το όνομα από το επώνυμο με βάση τον χαρακτήρα κενό ' ', όπου ισχύουν οι ίδιες προδιαγραφές και για τα δύο
         *      [2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3
         *      [2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15
         *      [2.3] Πρέπει να περιέχει μόνο γράμματα
         *      [2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο
         *      [2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά
         *      [2.6] Τα γράμματα πρέπει να είναι όλα λατινικά
         */
        public bool ValidName(string Name) /* TIGER */
        {
            // [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά
            string[] subNames = Name.Split(' ');
            if (subNames.Length != 2)
                return false;

            // [2] Ξεχωρίζουμε το όνομα από το επώνυμο με βάση τον χαρακτήρα κενό ' ', όπου ισχύουν οι ίδιες προδιαγραφές και για τα δύο
            string firstName = subNames[0];
            string lastName = subNames[1];

            // [2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3
            if (firstName.Length < 3)
                return false;
            if (lastName.Length < 3)
                return false;

            // [2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15
            if (firstName.Length > 15)
                return false;
            if (lastName.Length > 15)
                return false;

            // [2.3] Πρέπει να περιέχει μόνο γράμματα
            if (!firstName.All(char.IsLetter))
                return false;
            if (!lastName.All(char.IsLetter))
                return false;

            // [2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο
            char[] firstNameArray = firstName.ToCharArray();
            char[] lastNameArray = lastName.ToCharArray();
            if (!char.IsUpper(firstNameArray[0]))
                return false;
            if (!char.IsUpper(lastNameArray[0]))
                return false;

            // [2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά
            if (!firstName.Substring(1).All(char.IsLower))
                return false;
            if (!lastName.Substring(1).All(char.IsLower))
                return false;

            // [2.6] Τα γράμματα πρέπει να είναι όλα λατινικά
            bool isLatinLetter = true;
            for (int i = 0; i < firstNameArray.Length; i++)
            {
                isLatinLetter = (firstNameArray[i] >= 'A' && firstNameArray[i] <= 'Z') || (firstNameArray[i] >= 'a' && firstNameArray[i] <= 'z');
                if (!isLatinLetter)
                    return false;
            }
            for (int j = 0; j < lastNameArray.Length; j++)
            {
                isLatinLetter = (lastNameArray[j] >= 'A' && lastNameArray[j] <= 'Z') || (lastNameArray[j] >= 'a' && lastNameArray[j] <= 'z');
                if (!isLatinLetter)
                    return false;
            }

            // Έγκυρο ονοματεπώνυμο
            return true;                              
        } 

        /*
         * προδιαγραφες κωδικου(password)
         * [1] Τουλάχιστον 12 χαρακτήρες
         * [2] Tο πολυ 24 χαρακτηρες
         * [3] Συνδυασμός χαρακτηριών
         * [3.1] τουλαχιστον 1 κεφαλαιο 
         * [3.2] τουλαχιστον ενα πεζο
         * [3.3] τουλαχισοτν 1 νουμερο
         * [3.4] τουλαχιαοτν 1 ειδικο συμβολο
         * [4] χαρακτηρες διαφυγης 
         * [5] Τα γράμματα να είναι λατινικοί χαρακτήρες
         * [6] Να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με αριθμό
         * 
         * 
         */
         public bool ValidPassword(string Password) /* THEO */

        {
            char[] passwordArray = Password.ToCharArray();
            // [1] Έλεγχος για μήκος τουλάχιστον 12 χαρακτήρες
            if (Password.Length < 12)
            {
                return false;
            }
            // [2] Tο πολυ 24 χαρακτηρες
            if (Password.Length > 24)
            {
                return false;
            }
            //[3.1] Έλεγχος για κεφαλαία γράμματα
            if (!Password.Any(char.IsUpper))
            {
                return false;
            }
            //[3.2] Έλεγχος για πεζά γράμματα
            if (!Password.Any(char.IsLower))
            {
                return false;
            }
            // [3.3] Έλεγχος για αριθμούς
            if (!Password.Any(char.IsDigit))
            {
                return false;
            }
            
            // [3.4] τουλαχιαοτν 1 ειδικο συμβολo
            if (!Password.Any(symbol => "!@#$%^&*()_+-=[]{}|;:'\",.<>/?".Contains(symbol)))
            {
                return false;
            }
            // [4] Έλεγχος για χαρακτηρες διαφυγης
            if (Password.Any(char.IsWhiteSpace))
            {
                return false;
            }


            // [5] Τα γράμματα πρέπει να είναι όλα λατινικά
            bool isLatinLetter = true;
            for (int i = 0; i < passwordArray.Length; i++)
            {
                if (char.IsLetter(passwordArray[i]))
                {
                    isLatinLetter = (passwordArray[i] >= 'A' && passwordArray[i] <= 'Z') || (passwordArray[i] >= 'a' && passwordArray[i] <= 'z');
                    if (!isLatinLetter)
                        return false;
                }
            }
            
               

            //[6] Έλεγχος ότι ξεκινάει από κεφαλαίο και τελειώνει με αριθμό
            if (!(char.IsUpper(Password[0]) && char.IsDigit(Password[Password.Length - 1])))
            {
                return false;
            }

            return true;
        }
            



            }
        }
