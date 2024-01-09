using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib;

namespace HRLibUnitTest
{
    [TestClass]
    public class UnitTestPersonnel
    {
        [TestMethod]
        public void TestMethodValidName() /* TIGER */
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();
            /*  Γράψ'τε σε μία κενή γραμμή per. (π.χ. την 18) και θα σας εμφανίσει τις μεθόδους...
             *  Έχει και άλλες 4 που είναι μέθοδοι της κλάσης object που κληρονομούν ΌΛΕΣ οι κλάσεις που φτιάχνουμε
             */

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            /*  { id testcase,  
             *    ημερομηνία,
             *    τιμή που περιμένω να επιστρέψει η μέθοδος ValidName(),
             *    μήνυμα που αιτιολογεί τις πληροφορίες που περιμένω
             *  }
             */
                { 1, "12345 @_/", true, "Περιέχει νούμερα και χαρακτήρες διαφυγής πέρα του κενού ' '" },
                { 2, "George_Theoxaris", true, "Περιέχει χαρακτήρα διαφυγής '_' που δεν είναι το κενό ' '" },
                { 3, "Geo rge Theo", false, "Περιέχει δύο χαρακτήρες κενό ' '" },
                { 4, "George Theoxaris", true, "Έγκυρο ονοματεπώνυμο" },
                { 5, "OmarAlhaz", false, "Δεν περιέχει τον χαρακτήρα διαφυγής ' '" },
                { 6, "vasilis athanasiou", false, "Τα αρχικά του ονοματεπώνυμου δεν είναι με κεφαλαία" },
                { 7, "Βασίλης Αθανασίου", false, "Δεν περιέχει λατινικά γράμματα" },
                { 8, "Omaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaar Alhaz", false, "Το ονοματεπώνυμο έχει περισσότερα από 24 γράμματα" },
                { 9, "Omar Alhaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaz", false, "Το ονοματεπώνυμο έχει περισσότερα από 24 γράμματα" },
                { 10, " Vasilisathanasiou", false, "Ο χαρακτήρας κενό ' ' δεν είναι ανάμεσα στα γράμματα" },
                { 11, "Vasilisathanasiou ", true, "Ο χαρακτήρας κενό ' ' δεν είναι ανάμεσα στα γράμματα" },
                { 12, "VaSiLis Athanasiou", false, "Κεφαλαίο γράμμα στα ενδιάμεσα γράμματα" },
                { 13, "Omar Alhaz", false, "Έγκυρο ονοματεπώνυμο" }
            };

            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    string Name = (string)testcases[i, 1];
                    bool expectedValue = (bool)testcases[i, 2]; // Η τιμή που περιμένω να επιστρέψει η μέθοδος ValidName() για την ημερομηνία i
                    bool actualValue = per.ValidName(Name); // Η τιμή που επιστρέφει η μέθοδος ValidName() για την ημερομηνία i
                    Assert.AreEqual(expectedValue, actualValue);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //  id, μήνυμα που αιτιολογεί τις πληροφορίες που περιμένω, μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodValidPassword() /* THEO */
        {


            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();
            /*  Γράψ'τε σε μία κενή γραμμή per. (π.χ. την 18) και θα σας εμφανίσει τις μεθόδους...
             *  Έχει και άλλες 4 που είναι μέθοδοι της κλάσης object που κληρονομούν ΌΛΕΣ οι κλάσεις που φτιάχνουμε
             */

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            /*  { id testcase,  
             *    ημερομηνία,
             *    τιμή που περιμένω να επιστρέψει η μέθοδος ValidPassword(),
             *    μήνυμα που αιτιολογεί τις πληροφορίες που περιμένω
             *  }
             */
         /*προδιαγραφες κωδικου(password)
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
         */
                { 1, "Ako2", false, "    [1] Τουλάχιστον 12 χαρακτήρες" },
                { 2, "Akkakanhfhfhrbfhbyrbtybytbh4#$fhbrvhvb1",false,"[2] Tο πολυ 24 χαρακτηρες" },
                { 3, "Vasilisathanο#6" ,true," εγκυρος κωδκος "},
                { 4, "γιωργοςπαδα2024",false,"[5] Τα γράμματα να είναι λατινικοί χαρακτήρες"},
                { 5, "omaraAlhaz2001",false," [6]  Να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με αριθμό"},
                { 6, "Koaos^klpoplkjg",false,"[6] Να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με αριθμό" },
                { 7, "Georgetheo@#$9",true,"εγκυρος κωδικος " },
                { 8,"!@#$%^&**&^%$#@!",false,"[3] Συνδυασμός χαρακτηριών" },

            };


            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    string Password = (string)testcases[i, 1];
                    bool expectedValue = (bool)testcases[i, 2]; // Η τιμή που περιμένω να επιστρέψει η μέθοδος ValidPassword() για την ημερομηνία i
                    bool actualValue = per.ValidPassword(Password); // Η τιμή που επιστρέφει η μέθοδος ValidPassword() για την ημερομηνία i
                    Assert.AreEqual(expectedValue, actualValue);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //  id, μήνυμα που αιτιολογεί τις πληροφορίες που περιμένω, μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }
    }
}

     

        

        
        