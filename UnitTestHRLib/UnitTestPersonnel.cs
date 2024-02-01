using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.Personnel;

namespace HRLibUnitTest
{
    [TestClass]
    public class UnitTestPersonnel
    {
        [TestMethod]
        public void TestMethodValidName() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            //  { id,    "Ονοματεπώνυμο",          εκτιμώμενη τιμή      "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                 επιστροφής της ValidName                      
                { 1,     "VasilisAthanasiou",          true,             "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { 2,     "George Theo Xaris",          true,             "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { 3,     "Om Alhaz",                   true,             "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { 4,     "Vasilis At",                 true,             "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { 5,     "Georgeeeeeeeeeee Theoxaris", true,             "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { 6,     "Omar Alhaaaaaaaaaaaaz",      true,             "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { 7,     "Vasilis123 Athanasiou",      true,             "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { 8,     "George Theo_xaris",          true,             "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { 9,     "omar Alhaz",                 true,             "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { 10,    "Vasilis athanasiou",         true,             "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { 11,    "GeorGe Theoxaris",           true,             "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { 12,    "Omar AlhAz",                 true,             "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { 13,    "Βασίλης Athanasiou",         true,             "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { 14,    "George Θεοχάρης",            true,             "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { 15,    "Omar Alhaz",                 false,            "Έγκυρο ονοματεπώνυμο" },
                { 16,    "Vasilis Athanasiou",         false,            "Έγκυρο ονοματεπώνυμο" },
                { 17,    "George Theoxaris",           false,            "Έγκυρο ονοματεπώνυμο" }
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
                    bool expectedValue = (bool)testcases[i, 2];  // Η τιμή που περιμένω να επιστρέψει η μέθοδος ValidName() για την ημερομηνία i
                    bool actualValue = per.ValidName(Name);      // Η τιμή που επιστρέφει η μέθοδος ValidName() για την ημερομηνία i
                    Assert.AreEqual(expectedValue, actualValue);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodValidPassword() 
        { 
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            { 
            //  { id,    "Κωδικός",                      εκτιμώμενη τιμή           "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                      επιστροφής της ValidPassword
                { 1,      "Ako2",                             true,                 "[1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 12" },
                { 2,      "Akkakbfpaoqweh!@#1224hhff1",       true,                 "[2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 24" },
                { 3,      "!@#$%^&**&^%$#@!",                 true,                 "[3] Συνδυασμός χαρακτήρων"},
                { 4,      "george@12#po12" ,                  true,                 "[3.1] Να περιέχει τουλάχιστον 1 κεφαλαίο γράμμα"},
                { 5,      "OMARGYPAS2!@13",                   true,                 "[3.2] Να περιέχει τουλάχιστον ένα πεζό γράμμα"},
                { 6,      "Ath@n@siouvasil",                  true,                 "[3.3] Να περιέχει τουλάχιστον 1 ψηφίο"},
                { 7,      "George2001theo13",                 true,                 "[3.4] Να περιέχει τουλάχιστον 1 ειδικό σύμβολο"},
                { 8,      "George!@#13 hf" ,                  true,                 "[4] Να μην περιέχει χαρακτήρες διαφυγής"},
                { 9,      "Γιωργοςπαδα@2024",                 true,                 "[5] Τα γράμματα πρέπει να είναι λατινικοί χαρακτήρες"},
                { 10,     "omara#Alhaz2001",                  true,                 "[6.1] Πρέπει να ξεκινάει από κεφαλαίο γράμμα"},
                { 11,     "Koaos1^klpoplkjg",                 true,                 "[6.2] Πρέπει να τελειώνει με ψηφίο" },
                { 12,     "Georgethe8o@#$9",                  false,                "Έγκυρος κωδικός πρόσβασης" },
                { 13,     "Vasilisatha8no#6",                 false,                "Έγκυρος κωδικός πρόσβασης" },
                { 14,     "Omar_@Alhaz123",                   false,                "Έγκυρος κωδικός πρόσβασης" } 
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
                    bool expectedValue = (bool)testcases[i, 2];     // Η τιμή που περιμένω να επιστρέψει η μέθοδος ValidPassword() για την ημερομηνία i
                    bool actualValue = per.ValidPassword(Password); // Η τιμή που επιστρέφει η μέθοδος ValidPassword() για την ημερομηνία i
                    Assert.AreEqual(expectedValue, actualValue);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }
    

        [TestMethod]
        public void TestMethodEncryptPassword() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
                //  { id,    "Κωδικός",                      εκτιμώμενη τιμή           "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
                //                                      επιστροφής της ValidPassword
                {      1,    "theodosis123",                    "hhhhhhh",             "Οι αναλυτές είναι πάνω από τους προγραμματιστές" }
                
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
                    string TestcasePW = (string)testcases[i, 1];       // Το τηλέφωνο του testcase i 
                    string ExpectedEnPW = (string)testcases[i, 2];         // Ο τύπος τηλεφώνου του testcase i που περιμένω να επιστρέψει η CheckPhone() 
                   

                    // Δήλωση και αρχικοποίηση ref μεταβλητών μεθόδου
                    string ActualEnPW = "";

                    per.EncryptPassword(TestcasePW, ref ActualEnPW);

                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(ExpectedEnPW, ActualEnPW);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }

        [TestMethod]
        public void TestMethodCheckPhone() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,     "Αριθμός Τηλεφώνου",    εκτιμώμενη τιμή επιστροφής             εκτιμώμενη τιμή επιστροφής                             "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
             //                                της CheckPhone() στην TypePhone         της CheckPhone() στην InfoPhone   
                { 1,      "210-124567",                        0,                                 null,                                         "[1] Να περιέχει μόνο αριθμούς" },
                { 2,      "210-124567",                       -1,                    "Metropolitan Area of Athens - Piraeus",                   "[1] Να περιέχει μόνο αριθμούς" },
                { 3,      "690A49898c",                        1,                                 null,                                         "[1] Να περιέχει μόνο αριθμούς" },
                { 4,      "690A49898c",                       -1,                                "Nova",                                        "[1] Να περιέχει μόνο αριθμούς" },
                { 5,      "22314",                             0,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 6,      "22314",                            -1,              "Eastern Central Greece, Attica, Aegean Islands",                "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 7,      "69312",                             1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 8,      "69312",                            -1,                                "Nova",                                        "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 9,      "23444444444444",                    0,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 10,     "23444444444444",                   -1,                           "Central Macedonia",                                "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 11,     "69988888888888",                    1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 12,     "69988888888888",                   -1,                                "Nova",                                        "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 13,     "140124567",                         0,                                 null,                                         "[3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό" },
                { 14,     "140124567",                         0,                       "Thessaly, Western Macedonia",                          "[3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό" },
                { 15,     "2001010101",                        0,                                 null,                                         "[3.1] Να ανήκει σε ζώνη" },
                { 16,     "2001010101",                       -1,       "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands",  "[3.1] Να ανήκει σε ζώνη" },
                { 17,     "2101010101",                        0,                "Metropolitan Area of Athens - Piraeus",                       "Έγκυρο σταθερό τηλέφωνο με ζώνη την Μητροπολιτική Περιοχή Αθήνας - Πειραιά" },
                { 18,     "2201010101",                        0,             "Eastern Central Greece, Attica, Aegean Islands",                 "Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου" },
                { 19,     "2301010101",                        0,                            "Central Macedonia",                               "Έγκυρο σταθερό τηλέφωνο με ζώνη την Κεντρική Μακεδονία" },
                { 20,     "2401010101",                        0,                        "Thessaly, Western Macedonia",                         "Έγκυρο σταθερό τηλέφωνο με ζώνη την Θεσσαλία, Δυτική Μακεδονία" },
                { 21,     "2501010101",                        0,                            "Thrace, Eastern Macedonia",                       "Έγκυρο σταθερό τηλέφωνο με ζώνη την Θράκη, Ανατολική Μακεδονία" },
                { 22,     "2601010101",                        0,       "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands",  "Έγκυρο σταθερό τηλέφωνο με ζώνη την Ήπειρο, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησο, Ιόνια Νησιά" },
                { 23,     "2701010101",                        0,                        "Eastern Peloponnese, Kythera",                        "Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Πελοπόννησο, Κύθηρα" },
                { 24,     "2801010101",                        0,                                "Crete",                                       "Έγκυρο σταθερό τηλέφωνο με ζώνη την Κρήτη" },
                { 25,     "2901010101",                        0,                                 null,                                         "[3.1] Να ανήκει σε ζώνη" },
                { 26,     "2901010101",                       -1,                       "Thrace, Eastern Macedonia",                            "[3.1] Να ανήκει σε ζώνη" },
                { 27,     "6900101010",                        1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova"},
                { 28,     "6910101010",                        1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { 29,     "6910101010",                       -1,                               "Vodafone",                                     "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { 30,     "6920101010",                        1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { 31,     "6920101010",                       -1,                                "Cosmote",                                     "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { 32,     "6930101010",                        1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova"},
                { 33,     "6940101010",                        1,                                "Vodafone",                                    "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone"},
                { 34,     "6950101010",                        1,                                "Vodafone",                                    "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone"},
                { 35,     "6960101010",                        1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { 36,     "6960101010",                       -1,                                "Cosmote",                                     "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { 37,     "6970101010",                        1,                                "Cosmote",                                     "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote"},
                { 38,     "6980101010",                        1,                                "Cosmote",                                     "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote"},
                { 39,     "6990101010",                        1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο"}
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
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (int)testcases[i, 0], (string)testcases[i, 4], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodInfoEmployee() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            Employee[] emps = new Employee[]
            {
                new Employee("George", "2102322751", "6998843565", new DateTime(2001, 03, 01), new DateTime(2023, 01, 02)),
                // new Employee(...)
            };

            /*
             *  Πρέπει να ελέγχει και το όνομα (ValidName) και τα τηλέφωνα (CheckPhone)?
             */

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,    "Υπάλληλος",            εκτιμώμενη τιμή επιστροφής,          εκτιμώμενη τιμή επιστροφής,                      "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
             //                                  της InfoEmployee() στην Age     της InfoEmployee() στην YearsOfExperience              
                { 1,        emps[0],                        21,                                    1,                                  "Ο υπάλληλος είναι 22 χρονών και έχει 1 χρόνο υπηρεσίας" },
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
                    Employee TestcaseEmployee = (Employee)testcases[i, 1];       // Ο υπάλληλος του testcase i 
                    int ExpectedAge = (int)testcases[i, 2];                      // Η ηλικία του υπαλλήλου του testcase i που περιμένω να επιστρέψει η InfoEmployee() 
                    int ExpectedYearsOfExperience = (int)testcases[i, 3];        // Τα χρόνια υπηρεσίας του υπαλλήλου του testcase i που περιμένω να επιστρέψει η InfoEmployee()

                    // Δήλωση και αρχικοποίηση ref μεταβλητών μεθόδου
                    int ActualAge = 0;
                    int ActualYearsOfExperience = 100;

                    per.InfoEmployee(TestcaseEmployee, ref ActualAge, ref ActualYearsOfExperience);

                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(ExpectedAge, ActualAge);
                    Assert.AreEqual(ExpectedYearsOfExperience, ActualYearsOfExperience);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (int)testcases[i, 0], (string)testcases[i, 4], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }

        [TestMethod]
        public void TestMethodLiveInAthens() 
        {

        }

    }
}
