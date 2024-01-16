using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib;
using static HRLib.Personnel.Employee;

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

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,    "Ονοματεπώνυμο",         εκτιμώμενη τιμή       "Προδιαγραφή της ValidName() που παραβιάζεται ή μήνυμα έγκυρου ονοματεπωνύμου"}
             //                               επιστροφής της ValidName                      
                { 1,     "VasilisAthanasiou",          false,           "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { 2,     "George Theo Xaris",          false,           "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { 3,     "Om Alhaz",                   false,           "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { 4,     "Vasilis At",                 false,           "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { 5,     "Georgeeeeeeeeeee Theoxaris", false,           "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { 6,     "Omar Alhaaaaaaaaaaaaz",      false,           "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { 7,     "Vasilis123 Athanasiou",      false,           "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { 8,     "George Theo_xaris",          false,           "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { 9,     "omar Alhaz",                 false,           "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { 10,    "Vasilis athanasiou",         false,           "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { 11,    "GeorGe Theoxaris",           false,           "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { 12,    "Omar AlhAz",                 false,           "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { 13,    "Βασίλης Athanasiou",         false,           "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { 14,    "George Θεοχάρης",            false,           "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { 15,    "Omar Alhaz",                 true,            "Έγκυρο ονοματεπώνυμο" },
                { 16,    "Vasilis Athanasiou",         true,            "Έγκυρο ονοματεπώνυμο" },
                { 17,    "George Theoxaris",           true,            "Έγκυρο ονοματεπώνυμο" }
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
                { 1, "Ako2",                      false, "[1]    Τουλάχιστον 12 χαρακτήρες" },
                { 2, "Akkakbfpaoqweh!@#1224hhff1",false, "[2]    Tο πολυ 24 χαρακτηρες" },
                { 3, "!@#$%^&**&^%$#@!",          false, "[3]    Συνδυασμός χαρακτηριών"},
                { 4, "george@12#po12" ,           false, "[3.1]  Τουλαχιστον 1 κεφαλαιο"},
                { 5, "OMARGYPAS2!@13",            false, "[3.2]  Τουλαχιστον ενα πεζο"},
                { 6, "Ath@n@siouvasil",           false, "[3.3]  Τουλαχισοτν 1 νουμερο"},
                { 7, "George2001theo13",          false, "[3.4]  Τουλαχιαοτν 1 ειδικο συμβολο"},
                { 8, "George!@#13 hf" ,           false, "[4]    Χαρακτηρες διαφυγης"},
                { 9, "Γιωργοςπαδα@2024",          false, "[5]    Τα γράμματα να είναι λατινικοί χαρακτήρες"},
                { 10, "omara#Alhaz2001",          false, "[6]    Να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με αριθμό"},
                { 11, "Koaos1^klpoplkjg",         false, "[6]    Να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με αριθμό" },
                { 12, "Georgethe8o@#$9",           true, "[7]    Εγκυρος κωδικος  "},
                { 13,"Vasilisatha8no#6",           true, "[7]    Εγκυρος κωδκος   "},
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
             // {id,      "Αριθμός Τηλεφώνου",    εκτιμώμενη τιμή επιστροφής           εκτιμώμενη τιμή επιστροφής                              "Προδιαγραφή της CheckPhone που παραβιάζεται ή μήνυμα έγκυρου αριθμού τηλεφώνου"
             //                                της CheckPhone() στην TypePhone    της CheckPhone() στην InfoPhone   
                { 1,      "69A149898c",                       -1,                                 null,                                         "[1] Να περιέχει μόνο αριθμούς" },
                { 2,      "210-124567",                       -1,                                 null,                                         "[1] Να περιέχει μόνο αριθμούς" },
                { 3,      "69412",                            -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 4,      "21314",                            -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 5,      "69888888888888",                   -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 6,      "21444444444444",                   -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { 7,      "110124567",                         0,                "Metropolitan Area of Athens - Piraeus",                       "[3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό" },
                { 8,      "5971456562",                        1,                               "Cosmote",                                      "[4] Να ξεκινάει σε 69 αν πρόκειται για κινητό" },
                { 9,      "2001010101",                       -1,                                 null,                                         "[3.1] Να ανήκει σε ζώνη" },
                { 10,     "2101010101",                        0,                "Metropolitan Area of Athens - Piraeus",                       "Έγκυρο σταθερό τηλέφωνο στην ζώνη Μητροπολιτική Περιοχή Αθήνας - Πειραιά" },
                { 11,     "2201010101",                        0,             "Eastern Central Greece, Attica, Aegean Islands",                 "Έγκυρο σταθερό τηλέφωνο στην ζώνη Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου" },
                { 12,     "2301010101",                        0,                            "Central Macedonia",                               "Έγκυρο σταθερό τηλέφωνο στην ζώνη Κεντρική Μακεδονία" },
                { 13,     "2401010101",                        0,                        "Thessaly, Western Macedonia",                         "Έγκυρο σταθερό τηλέφωνο στην ζώνη Θεσσαλία, Δυτική Μακεδονία" },
                { 14,     "2501010101",                        0,                            "Thrace, Eastern Macedonia",                       "Έγκυρο σταθερό τηλέφωνο στην ζώνη Θράκη, Ανατολική Μακεδονία" },
                { 15,     "2601010101",                        0,       "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands",  "Έγκυρο σταθερό τηλέφωνο στην ζώνη Ήπειρος, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησος, Ιόνια Νησιά" },
                { 16,     "2701010101",                        0,                        "Eastern Peloponnese, Kythera",                        "Έγκυρο σταθερό τηλέφωνο στην ζώνη Ανατολική Πελοπόννησος, Κύθηρα" },
                { 17,     "2801010101",                        0,                                "Crete",                                       "Έγκυρο σταθερό τηλέφωνο στην ζώνη Κρήτη" },
                { 18,     "2901010101",                       -1,                                  null,                                        "[3.1] Να ανήκει σε ζώνη" },
                { 19,     "6900101010",                        1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova"},
                { 20,     "6910101010",                       -1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας"},
                { 21,     "6920101010",                       -1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας"},
                { 22,     "6930101010",                        1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova"},
                { 23,     "6940101010",                        1,                                "Vodafone",                                    "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone"},
                { 24,     "6950101010",                        1,                                "Vodafone",                                    "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone"},
                { 25,     "6960101010",                       -1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας"},
                { 26,     "6970101010",                        1,                                "Cosmote",                                     "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote"},
                { 27,     "6980101010",                        1,                                "Cosmote",                                     "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote"},
                { 28,     "6990101010",                        1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο"}
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
                        (int)testcases[i, 0], (string)testcases[i, 4], e.Message);
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
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            Employee Emp1 = new Employee("George", "2102322751", "6998843565", new DateTime(2001, 03, 01), new DateTime(2023, 01, 02));
            


            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,    "Υπάλληλος",         εκτιμώμενη τιμή επιστροφής,          εκτιμώμενη τιμή επιστροφής,                     "Προδιαγραφή της InfoEmployee() που παραβιάζεται ή έγκυρης ηλικίας υπαλλήλου ή έγκυρα χρόνια υπηρεσίας"}
             //                                της InfoEmployee() στην Age     της InfoEmployee() στην YearsOfExperience              
                { 1,        Emp1,                        22,                                   1,                                  "Ο υπάλληλος είναι 22 χρονών και έχει 1 χρόνο υπηρεσίας" },
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
                    Employee TestcaseEmployee = (Employee)testcases[i, 1];       // Το τηλέφωνο του testcase i 
                    int ExpectedAge = (int)testcases[i, 2];         // Ο τύπος τηλεφώνου του testcase i που περιμένω να επιστρέψει η CheckPhone() 
                    int ExpectedYearsOfExperience = (int)testcases[i, 3];   // Οι πληροφορίες τηλεφώνου του testcase i που περιμένω να επιστρέψει η CheckPhone()

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
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ",
                        (int)testcases[i, 0], (string)testcases[i, 4], e.Message);
                    //  id, μήνυμα που αιτιολογεί τις πληροφορίες που περιμένω, μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }

        [TestMethod]
        public void TestMethodLiveInAthens() /* OMAR */
        {

        }

    }
}
