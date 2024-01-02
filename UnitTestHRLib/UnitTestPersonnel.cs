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

            object[,] testcases =
            
            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;
        }

        [TestMethod]
        public void TestMethodEncryptPassword() /* OMAR */
        {

        }

        [TestMethod]
        public void TestMethodCheckPhone() /* TIGER */
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            /*  { id testcase,  
             *    τηλέφωνο,
             *    τύπος τηλεφώνου που περιμένω να επιστρέψει η CheckPhone(),
             *    πληροφορίες τηλεφώνου που περιμένω να επιστρέψει η CheckPhone(),
             *    μήνυμα που αιτιολογεί τις πληροφορίες που περιμένω 
             *  } 
             */
                { 1, "2100000000", 0, "Metropolitan Area of Athens - Piraeus", "Σταθερό τηλέφωνο με ζώνη την Μητροπολιτική περιοχή Αθήνας - Πειραιά" },
                { 2, "2200000000", 0, "Eastern Central Greece, Attica, Aegean Islands", "Σταθερό τηλέφωνο με ζώνη την Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου" },
                { 3, "2300000000", 0, "Central Macedonia", "Σταθερό τηλέφωνο με ζώνη την Κεντρική Μακεδονία" },
                { 4, "2400000000", 0, "Thessaly, Western Macedonia", "Σταθερό τηλέφωνο με ζώνη την Θεσσαλία, Δυτική Μακεδονία" },
                { 5, "2500000000", 0, "Thrace, Eastern Macedonia", "Σταθερό τηλέφωνο με ζώνη την Θράκη, Ανατολική Μακεδονία" },
                { 6, "2600000000", 0, "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands", "Σταθερό τηλέφωνο με ζώνη την Ήπειρο, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησος, Ιόνια Νησιά" },
                { 7, "2700000000", 0, "Eastern Peloponnese, Kythera", "Σταθερό τηλέφωνο με ζώνη την Ανατολική Πελοπόννησο, Κύθηρα" },
                { 8, "2800000000", 0, "Crete", "Σταθερό τηλέφωνο με ζώνη την Κρήτη" },
                { 9, "2900000000", 0, null, "Σταθερό τηλέφωνο με καμία ζώνη" },
                { 10, "6900000000", 1, "Nova", "Κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova" },
                { 11, "6930000000", 1, "Nova", "Κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova" },
                { 12, "6990000000", 1, "Nova", "Κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova" },
                { 13, "6940000000", 1, "Vodafone", "Κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone" },
                { 14, "6950000000", 1, "Vodafone", "Κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone" },
                { 15, "6970000000", 1, "Cosmote", "Κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote" },
                { 16, "6980000000", 1, "Cosmote", "Κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote" },
                { 17, "6920000000", 1, null, "Κινητό τηλέφωνο με καμία εταιρία κινητής τηλεφωνίας" },
                { 18, "4562389784", -1, null, "Άκυρο κινητό" },
                { 19, "210A28221", -1, null, "Άκυρο κινητό" },
                { 20, "698_141312", -1, null, "Άκυρο κινητό" }
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
                    string TestcasePhone = (string)testcases[i, 1];       // Το τηλέφωνο του testcase i 
                    int ExpectedTypePhone = (int)testcases[i, 2];         // Ο τύπος τηλεφώνου του testcase i που περιμένω να επιστρέψει η CheckPhone() 
                    string ExpectedInfoPhone = (string)testcases[i, 3];   // Οι πληροφορίες τηλεφώνου του testcase i που περιμένω να επιστρέψει η CheckPhone()

                    // Δήλωση και αρχικοποίηση ref μεταβλητών μεθόδου
                    int ActualTypePhone = 100;
                    string ActualInfoPhone = "";

                    per.CheckPhone(TestcasePhone, ref ActualTypePhone, ref ActualInfoPhone);

                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(ExpectedTypePhone, ActualTypePhone);
                    Assert.AreEqual(ExpectedInfoPhone, ActualInfoPhone);
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
        public void TestMethodInfoEmployee() /* THEO */
        {

        }

        [TestMethod]
        public void TestMethodLiveInAthens() /* OMAR */
        {

        }

    }
}
