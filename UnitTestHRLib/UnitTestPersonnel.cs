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

            // Δημιουργία δεδομένων για τις περιπτώσεις ελέγχου (Test Cases)
            /* Δεδομένα 1ου ονοματεπώνυμου */
            string name1 = "12345 @_/";
            string msg1 = "Περιέχει νούμερα και χαρακτήρες διαφυγής πέρα του κενού ' '";
            bool isName1 = true;
            /* Δεδομένα 2ου ονοματεπώνυμου */
            string name2 = "George_Theoxaris";
            string msg2 = "Περιέχει χαρακτήρα διαφυγής '_' που δεν είναι το κενό ' '";
            bool isName2 = true;
            /* Δεδομένα 3ου ονοματεπώνυμου */
            string name3 = "Geo rge Theo";
            string msg3 = "Περιέχει δύο χαρακτήρες κενό ' '";
            bool isName3 = false;
            /* Δεδομένα 4ου ονοματεπώνυμου */
            string name4 = "George Theoxaris";
            string msg4 = "Έγκυρο ονοματεπώνυμο";
            bool isName4 = true;
            /* Δεδομένα 5ου ονοματεπώνυμου */
            string name5 = "OmarAlhaz";
            string msg5 = "Δεν περιέχει τον χαρακτήρα διαφυγής ' '";
            bool isName5 = false;
            /* Δεδομένα 6ου ονοματεπώνυμου */
            string name6 = "vasilis athanasiou";
            string msg6 = "Τα αρχικά του ονοπατεπωνύμου δεν είναι με κεφαλαία";
            bool isName6 = false;
            /* Δεδομένα 7ου ονοματεπώνυμου */
            string name7 = "Βασίλης Αθανασίου";
            string msg7 = "Δεν περιέχει λατινικά γράμματα";
            bool isName7 = false;
            /* Δεδομένα 8ου ονοματεπώνυμου */
            string name8 = "Omaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaar Alhaz";
            string msg8 = "Το ονοματεπώνυμο έχει περισσότερα από 24 γράμματα";
            bool isName8 = false;
            /* Δεδομένα 9ου ονοματεπώνυμου */
            string name9 = "Omar Alhaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaz";
            string msg9 = "Το ονοματεπώνυμο έχει περισσότερα από 24 γράμματα";
            bool isName9 = false;
            /* Δεδομένα 10ου ονοματεπώνυμου */
            string name10 = " Vasilisathanasiou";
            string msg10 = "Ο χαρακτήρας κενό ' ' δεν είναι ανάμεσα στα γράμματα";
            bool isName10 = false;
            /* Δεδομένα 11ου ονοματεπώνυμου */
            string name11 = "Vasilisathanasiou ";
            string msg11 = "Ο χαρακτήρας κενό ' ' δεν είναι ανάμεσα στα γράμματα";
            bool isName11 = true;
            /* Δεδομένα 12ου ονοματεπώνυμου */
            string name12 = "VaSiLis Athanasiou";
            string msg12 = "Κεφαλαίο γράμμα στα ενδιάμεσα γράμματα";
            bool isName12 = false;
            /* Δεδομένα 13ου ονοματεπώνυμου */
            string name13 = "Omar Alhaz";
            string msg13 = "Έγκυρο ονοματεπώνυμο";
            bool isName13 = false;


            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            //  { id testcase, ημερομηνία, τιμή που περιμένω να επιστρέψει η μέθοδος isDate(), μήνυμα που εξηγεί την αλήθεια για την τιμή που περιμένω } 
                { 1, name1, isName1, msg1 },
                { 2, name2, isName2, msg2 },
                { 3, name3, isName3, msg3 },
                { 4, name4, isName4, msg4 },
                { 5, name5, isName5, msg5 },
                { 6, name6, isName6, msg6 },
                { 7, name7, isName7, msg7 },
                { 8, name8, isName8, msg8 },
                { 9, name9, isName9, msg9 },
                { 10, name10, isName10, msg10 },
                { 11, name11, isName11, msg11 },
                { 12, name12, isName12, msg12 },
                { 13, name13, isName13, msg13 }
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
                    bool expectedValue = (bool)testcases[i, 2]; // Η τιμή που περιμένω να επιστρέψει η μέθοδος isDate() για την ημερομηνία i
                    bool actualValue = per.ValidName(Name); // Η τιμή που επιστρέφει η μέθοδος isDate() για την ημερομηνία i
                    Assert.AreEqual(expectedValue, actualValue);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    // id testcase, μήνυμα που εξηγεί την αλήθεια για την τιμή που περιμένω, μήνυμα του exception 

                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodValidPassword() /* THEO */
        {

        }

        [TestMethod]
        public void TestMethodEncryptPassword() /* OMAR */
        {

        }

        [TestMethod]
        public void TestMethodCheckPhone() /* TIGER */
        {

        }

        [TestMethod]
        public void TestMethodInfoEmployee() /* THEO */
        {

        }

        [TestMethod]
        public void TestMethodLiveInAthens() /* OMAR */
        {

        }

    }
}
