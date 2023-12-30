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
         *  [1] Να περιέχει γράμματα
         *  [2] Να μην περιέχει οτιδήποτε δεν είναι γράμμα και ο χαρακτήρας ' ' 
         *  [3] Να υπάρχει ο χαρακτήρας διαφυγής κενό ' '
         *  [4] Ο χαρακτήρας κενό ' ' να είναι ανάμεσα στο 1ο και στο τελευταίο γράμμα
         *  [5] Να υπάρχει ο χαρακτήρας κενό ' ' ΑΚΡΙΒΩΣ 1 φορά
         *  [6] Να περιέχει μόνο λατινικά γράμματα
         *  [7] Το πρώτο γράμμα να είναι κεφαλαίο
         *  [8] Το αμέσως επόμενο γράμμα μετά τον χαρακτήρα κενό ' ' να είναι κεφαλαίο
         *  [9] Τα γράμματα από τον 2ο χαρακτήρα μέχρι τον αμέσως προηγούμενο από τον χαρακτήρα κενό ' ', να είναι μικρά
         *  [10] Τα γράμματα από τον αμέσως επόμενο χαρακτήρα από τον χαρακτήρα κενό ' ' μέχρι τον τελευταίο, να είναι μικρά
         *  [11] Οι χαρακτήρες πριν τον χαρακτήρα κενό ' ' να είναι λιγότεροι ή ίσοι από 24
         *  [12] Οι χαρακτήρες μετά τον χαρακτήρα κενό ' ' να είναι λιγότεροι ή ίσοι από 24
         */
        public bool ValidName(string Name) /* TIGER */
        {
            char[] nameArray = Name.ToCharArray();  // Μετατρέπω το string σε πίνακα χαρακτήρων
            int countSpace = 0;                     // Αρχικοποίηση της τιμής υπολογισμού των χαρακτήρων κενό ' ' 
            int indexSpace = -1;                    // Αρχικοποιώ την υποτιθέμενη θέση του χαρακτήρα κενό ' ' με θέση που είναι εκτός των ορίων του πίνακα 
            bool isLatin;                           // Μεταβλητή που χρησιμοποιείται για τον έλεγχο "αν το γράμμα είναι λατινικό"

            for (int i = 0; i < nameArray.Length; i++) // Προσπέλαση του πίνακα χαρακτήρων
            {
                /* 
                 *  [1] Να περιέχει γράμματα                 
                 */
                if (!char.IsLetter(nameArray[i])) // Ο χαρακτήρας i ΔΕΝ είναι γράμμα
                {
                    /* 
                     *   [2] Να μην περιέχει οτιδήποτε δεν είναι γράμμα και ο χαρακτήρας ' '                 
                     */
                    if (nameArray[i] != ' ') // Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ δεν είναι ο χαρακτήρας διαφυγής κενό ' '
                    {
                        return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [2] */
                    }
                    else // Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ είναι ο χαρακτήρας διαφυγής κενό ' '
                    {
                        /* 
                         *   [4] Ο χαρακτήρας κενό ' ' να είναι ανάμεσα στο 1ο και στο τελευταίο γράμμα                
                         */
                        if (i != 0 && i != nameArray.Length - 1) // Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ (ο χαρακτήρας i δεν είναι στην 1η θέση του πίνακα ΚΑΙ δεν είναι στην τελευταία)
                        {
                            countSpace++; // Ένδειξη ότι εντοπίστηκε ο χαρακτήρας κενό ' ' που να τηρεί την προδιαγραφή [4]
                            indexSpace = i; // Αποθήκευση της θέσης του χαρακτήρα κενό ' ' στον πίνακα
                            /* 
                             *   [5] Να υπάρχει ο χαρακτήρας κενό ' ' ΑΚΡΙΒΩΣ 1 φορά                
                             */
                            if (countSpace > 1) // Το πλήθος των χαρακτήρων διαφυγής κενό ' ' είναι περισσότερο από 1
                                return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [5] */
                        }
                        else // Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ (ο χαρακτήρας i είναι στην 1η θέση του πίνακα Ή είναι στην τελευταία)
                        {
                            return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [4] */
                        }
                    }
                }
                else // Ο χαρακτήρας i ΕΙΝΑΙ γράμμα
                {
                    /* 
                     *   [6] Να περιέχει μόνο λατινικά γράμματα                
                     */
                    isLatin = (nameArray[i] >= 'A' && nameArray[i] <= 'Z') || (nameArray[i] >= 'a' && nameArray[i] <= 'z'); // isLatin = Ο χαρακτήρας i βρίσκεται στο σύνολο [Α,Ζ] Ή στο σύνολο [a,z]
                    if (!isLatin) // !isLatin = Ο χαρακτήρας i ΔΕΝ βρίσκεται στο σύνολο [Α,Ζ] Ή στο σύνολο [a,z]
                        return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [6] */

                    if (indexSpace != -1) // Η θέση του χαρακτήρα διαφυγής κενό ' ' στον πίνακα έχει βρεθεί
                    {
                        if (i < indexSpace) // Ελέγχουμε τους χαρακτήρες από τον 2ο χαρακτήρα μέχρι τον αμέσως προηγούμενο από το χαρακτήρα κενό ' '
                        {
                            /*
                             *  [9] Τα γράμματα από τον 2ο χαρακτήρα μέχρι τον αμέσως προηγούμενο από τον χαρακτήρα κενό ' ', να είναι μικρά
                             */
                            if (!char.IsLower(nameArray[i])) // Ο χαρακτήρας i δεν είναι μικρό
                                return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [9] */
                        }
                        if (i > indexSpace + 1) // Ελέγχουμε τους χαρακτήρες από τον αμέσως επόμενο χαρακτήρα από τον χαρακτήρα κενό ' ', μέχρι τον τελευταίο
                        {
                            /*
                             *  [10] Τα γράμματα από τον αμέσως επόμενο χαρακτήρα από τον χαρακτήρα κενό ' ' μέχρι τον τελευταίο, να είναι μικρά
                             */
                            if (!char.IsLower(nameArray[i])) // Ο χαρακτήρας i δεν είναι μικρό
                                return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [10] */
                        }
                    }
                    else // Η θέση του χαρακτήρα διαφυγής κενό ' ' στον πίνακα ΔΕΝ έχει βρεθεί
                    {
                        if (i > 0)
                        {
                            /*
                             *  [9] Τα γράμματα από τον 2ο χαρακτήρα μέχρι τον αμέσως προηγούμενο από τον χαρακτήρα κενό ' ', να είναι μικρά
                             */
                            if (!char.IsLower(nameArray[i])) // Ο χαρακτήρας i δεν είναι μικρό
                                return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [9] */
                        }
                    }
                }
            }

            /*
             *   [3] Να υπάρχει ο χαρακτήρας διαφυγής κενό ' '
             */
            if (indexSpace == -1) // Ένδειξη ότι δεν βρέθηκε ο χαρακτήρας κενό ' '
                return false;  /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [3] */
            /*
             *  [7] Το πρώτο γράμμα να είναι κεφαλαίο
             */
            if (!char.IsUpper(nameArray[0])) // Το πρώτο γράμμα δεν είναι κεφαλαίο
                return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [7] */
            /*
             *  [8] Το αμέσως επόμενο γράμμα μετά τον χαρακτήρα κενό ' ' να είναι κεφαλαίο
             */
            if (!char.IsUpper(nameArray[indexSpace + 1])) //  Το αμέσως επόμενο γράμμα μετά τον χαρακτήρα κενό ' ' δεν είναι κεφαλαίο
                return false;  /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [8] */

            int charsBeforeSpace = (indexSpace - 1) - 0 + 1; // Υπολογισμός χαρακτήρων πριν τον χαρακτήρα κενό ' ' (ο τύπος είναι = τελευταία θέση στοιχείου - πρώτη θέση στοιχείου + 1)
            int charsAfterSpace = (nameArray.Length - 1) - (indexSpace - 1) + 1; // Υπολογισμός χαρακτήρων μετά τον χαρακτήρα κενό ' ' (ο τύπος είναι = τελευταία θέση στοιχείου - πρώτη θέση στοιχείου + 1)

            /*
             *  [11] Οι χαρακτήρες πριν τον χαρακτήρα κενό ' ' να είναι λιγότεροι ή ίσοι από 24 
             */
            if (charsBeforeSpace >= 24) // Οι χαρακτήρες πριν τον χαρακτήρα κενό ' ' είναι περισσότεροι ή ίσοι από 24
                return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [11] */
            /*
             *  [12] Οι χαρακτήρες μετά τον χαρακτήρα κενό ' ' να είναι λιγότεροι ή ίσοι από 24 
             */
            if (charsAfterSpace >= 24) // Οι χαρακτήρες μετά τον χαρακτήρα κενό ' ' είναι περισσότεροι ή ίσοι από 24
                return false; /* ΑΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Παραβίαση της προδιαγραφής [12] */

            return true; /* ΕΓΚΥΡΟ ΟΝΟΜΑΤΕΠΩΝΥΜΟ - Το όνομα τηρεί και τις 12 προδιαγραφές */
        } 

        public bool ValidPassword(string Password) /* THEO */
        {
            return true;
        }

        public void EncryptPassword(string Password, ref string EncryptedPW) /* OMAR */
        {
            
        }

        public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone) /* TIGER */
        {
            
        }

        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience) /* THEO */
        {
            
        }

        public int LiveinAthens(Employee[] Empls) /* OMAR */
        {
            return 0;
        }
    }
}