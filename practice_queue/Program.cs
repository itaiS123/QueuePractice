using System;
using Unit4.CollectionsLib;
namespace practice_queue
{
    class Program
    {
        public static void InsertToQueueInt(Queue<int> queue)
        {
            for (int i = 1; i <= 10; i++)
            {
                queue.Insert(i);
            }
        }
        public static int Count(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int count = 0;
            while (!q.IsEmpty())
            {
                count++;
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return count;
        }
        public static void PrintQ(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                Console.WriteLine(q.Head());
                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
        public static bool FindInQ(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            bool flage = false;
            while (!q.IsEmpty())
            {
                if (num == q.Head())
                {
                    flage = true;
                }
                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return flage;
        }
        public static Queue<int> Clone(Queue<int> q)
        {
            Queue<int> temp1 = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();

            while (!q.IsEmpty())
            {
                temp2.Insert(q.Head());
                temp1.Insert(q.Remove());
            }

            while (!temp1.IsEmpty())
            {
                q.Insert(temp1.Remove());
            }
            return temp2;
        }
        public static Queue<string> Clone(Queue<string> q)
        {
            Queue<string> temp1 = new Queue<string>();
            Queue<string> temp2 = new Queue<string>();

            while (!q.IsEmpty())
            {
                temp2.Insert(q.Head());
                temp1.Insert(q.Remove());
            }

            while (!temp1.IsEmpty())
            {
                q.Insert(temp1.Remove());
            }
            return temp2;
        }

        public static Queue<int> ArrToQueue(int[] arr)
        {
            Queue<int> q = new Queue<int>();
            foreach (int item in arr)
                q.Insert(item);
            return q;
        }
        public static Queue<string> ArrToQueue(string[] arr)
        {
            Queue<string> q = new Queue<string>();
            foreach (string item in arr)
                q.Insert(item);
            return q;
        }
        //   סכום איברים בתור .2 //
        public static int Sum(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int sum = 0;
            while (!q.IsEmpty())
            {
                sum += q.Head();
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return sum;
        }

        //    מספר מופעים של מספר.3 //
        public static int CountNum(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            int count = 0;
            while (!q.IsEmpty())
            {
                if (num == q.Head())
                {
                    count++;
                }

                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return count;
        }

        //.מוחקת את המופע הראשון של המספר .4 //
        //מחזירה שקר אם לא קיים // 
        public static bool RemoveNum(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            if (!FindInQ(q, num))
            {
                return false;
            }

            while (!q.IsEmpty())
            {
                if (num == q.Head())
                {
                    q.Remove();
                }

                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return true;
        }
        // מוחקת את כל המופעים את המספר ומחזירה כמה היו .5 //
        public static int CountAndRemove(Queue<int> q, int num)
        {
            int count = 0;
            Queue<int> tmp = new Queue<int>();
            while (!q.IsEmpty())
            {
                if (q.Head() == num)
                {
                    count++;
                    q.Remove();
                }
                else
                {
                    tmp.Insert(q.Remove());
                }
            }

            while (!tmp.IsEmpty())
            {
                q.Insert(tmp.Remove());
            }

            return count;
        }

        //   מוציאה ומחזירה את המספר האחרון בתור .6 //
        public static int GetLast(Queue<int> q)
        {
            Stack<int> temp1 = new Stack<int>();
            Stack<int> temp2 = new Stack<int>();


            while (!q.IsEmpty())
            {
                temp1.Push(q.Remove());
            }

            int last = temp1.Pop();
            while (!temp1.IsEmpty())
            {
                temp2.Push(temp1.Pop());
            }

            while (!temp2.IsEmpty())
            {
                q.Insert(temp2.Pop());
            }
            return last;
        }

        //   מחזיר אמת אם התור הוא פלינדרום .7 //
        public static bool IsPalindrom(Queue<int> q)
        {
            Queue<int> temp1 = Clone(q);
            Queue<int> temp2 = Clone(q);
            Stack<int> temp3 = new Stack<int>();
            bool flag = false;
            while (!temp1.IsEmpty())
            {
                temp3.Push(temp1.Remove());
            }

            while (!temp2.IsEmpty() && !temp3.IsEmpty())
            {
                if (temp2.Remove() == temp3.Pop())
                {
                    flag = true;
                }
            }

            return flag;
        }

        //    מוחק כפילויות .8 //
        public static void RemoveDuplicate(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>(); 

            while (!q.IsEmpty())
            {
                int current = q.Remove(); 

                if (!FindInQ(temp, current))
                {
                    temp.Insert(current); 
                }
            }

            while (!q.IsEmpty())
            {
                q.Remove();
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }

        //    מחזיר תור הפרשים בין כל זוג מספרים.9 // 
        public static Queue<int> DifferentialQ(Queue<int> q)
        {
            Queue<int> temp1 = Clone(q);
            Queue<int> temp2 = new Queue<int>();
            int num1 = 0;
            int num2 = 0;

            while (!temp1.IsEmpty())
            {
                num1 = temp1.Remove();
                if (!temp1.IsEmpty())
                {
                    num2 = temp1.Remove();
                    temp2.Insert(num1 - num2);
                }
            }

            return temp2;
        }
        ///    מתור של מספרים כפולים - מחזיר תור שהוא פלינדרום .10 // <summary>
        ///    מתור של מספרים כפולים - מחזיר תור שהוא פלינדרום .10 //
        /// עדיין לא עשיתי
        /// <param name="q"></param>
        /// <returns></returns>
        public static Queue<int> DuplicateQueue(Queue<int> q)
        {
            Stack<int> s = new Stack<int>();
            Queue<int> q1 = new Queue<int>();

            while (!q.IsEmpty())
            {
                s.Push(q.Remove());
                q1.Insert(q.Remove());
            }
            while (!s.IsEmpty())
                q.Insert(s.Pop());
            while (!q1.IsEmpty())
                q.Insert(q1.Remove());

            return q;
        }

        //  פצל את התור כל המספרים גדולים או שווים למספר ישארו בתור .11 //
        //השאר  יעברוו לתור חדש אותו מחזירים // 
        public static Queue<int> SplitQueue(Queue<int> q, int num)
        {
            Queue<int> s = new Queue<int>();
            Queue<int> q1 = Clone(q);

            while (!q1.IsEmpty())
            {
                if (q1.Head() < num)
                {
                    s.Insert(q1.Remove());
                }
                else
                {
                    q1.Remove();
                }
            }

            return s; 
        }

        //    פרוטקציה - מעבירה את האדם לראש התור.מחזירה שקר אם אין אדם כזה .12 //
        public static bool ProtectionQ(Queue<string> n, string name)
        {
            bool found = false;
            Queue<string> q = Clone(n);
            while (!q.IsEmpty())
            {
                if (q.Head() == name)
                {
                    found = true;
                }
                q.Remove();
            }

            q.Insert(name);
            while (!n.IsEmpty())
            {
                q.Insert(n.Remove());
            }

            while (!q.IsEmpty())
            {
                n.Insert(q.Remove());
            }

            return found;
        }

        //13. פעולה המקבלת תור 
        //  מחזירה תור חדש עם 
        //  איברים שהם מכפלת ערך הבלוק במספר המופעים
        // בלוק- רצף של לפחות שני אברים זהים
        //לתור
        //[5,5,0,0,0,2,3,-4,-4]                                  
        //[נקבל    [ -8, 0, 10   

        public static Queue<int> Rezef(Queue<int> q)
        {
            Queue<int> r = new Queue<int>();
            int value = 0;
            int count = 0;

            while (!q.IsEmpty())
            {

                value = q.Remove();
                count = 1;
                while (!q.IsEmpty() && q.Head() == value)
                {
                    count++;
                    q.Remove();
                }
                if (count > 1)
                    r.Insert(value * count);
                // count = 0;
            }

            return r;
        }

        //14. פעולה המקבלת תור ומחזירה אמת אם הוא ממויין בסדר עולה
        public static bool IsSort(Queue<int> q)
        {
            Queue<int> r = Clone(q);
            int lastNum = r.Head();
            r.Remove();
            while (!r.IsEmpty())
            {
                if (r.Head() < lastNum)
                {
                    return false;
                }
                lastNum = r.Head();
                r.Remove();
            }

            return true;
        }

        //15. הוספת מספר לתור ממויין 
        public static void AddToSort(Queue<int> q, int num)
        {
            Queue<int> r = new Queue<int>();
            int index = 0;

            while (!q.IsEmpty() && q.Head() < num)
            {
                r.Insert(q.Remove());
                index++;
            }

            r.Insert(num);

            while (!q.IsEmpty())
            {
                r.Insert(q.Remove());
            }

            while (!r.IsEmpty())
            {
                q.Insert(r.Remove());
            }
        }

        //16. העבר לתור חדש את המספרים המצויים בשני התורים 
        // והחזר אותו
        public static Queue<int> CommonNumberse(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> qNew = new Queue<int>();
            while (!q1.IsEmpty())
            {
                while (!q2.IsEmpty())
                {
                    if (q1.Head() == q2.Head())
                    {
                        qNew.Insert(q2.Remove());
                    }
                    else
                    {
                        q2.Remove();
                    }
                    q1.Remove();
                }
            }
            return qNew;
        }

        //17.פעולה המקבלת שני תורים ומחזירה תור חדש ממוזג של שניהם 
        //   שני התורים ממויינים 
        public static Queue<int> Merage(Queue<int> q1, Queue<int> q2)
        {
            while (!q1.IsEmpty())
            {
                AddToSort(q2, q1.Remove());
            }

            return q2;
        }

        public static int RemoveAllAndCount(Queue<int> q, int num)
        {
            int count = 0;
            Queue<int> temp = new Queue<int>();

            while (!q.IsEmpty())
            {
                int current = q.Remove();
                if (current == num)
                {
                    count++;
                }
                else
                {
                    temp.Insert(current);
                }
            }

            // Restore the elements back to the original queue
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return count;
        }
        // 18.  בגרות 205-2006 תור שכיחויות 
        // מחזיר לכל מספר את ערכו וכמה פעמים מופיע בתור
        // ,queue [1,4,4,1,5,-9,1,-9,-9]
        //[מחזיר  [3, 9-,1,3,4,2,5,1         
        public static Queue<int> Incidence(Queue<int> q)
        {
            // יש לשמור על התור המקורי 
            // פעולת עזר CountAndRemove(Queue<int> q,int num)
            Queue<int> newQ = new Queue<int>();
            Queue<int> tmp = Clone(q);
            while (!tmp.IsEmpty())
            {
                newQ.Insert(tmp.Head());
                newQ.Insert(RemoveAllAndCount(tmp, tmp.Remove()) + 1);
            }

            return newQ;
        }

        //19. בגרות 381-2020 
        // מקבל תור ומחזיר תור עם האברים שאינם בלוק 
        //בלוק- רצף של לפחות שני אברים זהים
        //[-4,-4, 3 , 2 , 0 , 0 , 0 , 0, 5 ,5,3  ]
        //  [3,2,3]  נקבל 
        // התרגיל המקורי על מחסנית 
        public static Queue<int> AntiBlock(Queue<int> q)
        {

            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--QUEUE--");
            Queue<int> q1 = ArrToQueue(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Queue<int> q2 = ArrToQueue(new int[] { 1, 5, 3, 8, 5, 6, 5 });
            Queue<int> q3 = ArrToQueue(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Queue<int> q4 = ArrToQueue(new int[] { 1, 2, 3, 4, 3, 2, 1});
            Queue<int> q5 = ArrToQueue(new int[] { 1, 3, 5, 6, 2, 3, 2, 1, 4, 5, 6, 7, 6 });
            Queue<int> q6 = ArrToQueue(new int[] { 10, 3, 6, 2, 4, 9, 3, 9, 1 });
            Queue<int> q10 = ArrToQueue(new int[] { 4, 7, 12, 65, 23, 5, 8 });
            Queue<string> q12 = ArrToQueue(new string[] { "Tal", "Noam", "Yael", "Rotem", "Dani", "Yosi" });
            Queue<int> q13 = ArrToQueue(new int[] { 5, 5, 5, 0, 0, 0, 0, 3, 2, -4, -4 });
            Queue<int> q141 = ArrToQueue(new int[] { 3, 5, 6, 8, 12 });
            Queue<int> q142 = ArrToQueue(new int[] { 3, 5, 9, 8, 12 });
            Queue<int> q15 = ArrToQueue(new int[] { 4, 6, 8, 10 });
            Queue<int> q161 = ArrToQueue(new int[] { 3, 5, 6, 8, 14 });
            Queue<int> q162 = ArrToQueue(new int[] { 2, 5, 9, 8, 12 });
            Queue<int> q171 = ArrToQueue(new int[] { 3, 5, 6, 8, 14 });
            Queue<int> q172 = ArrToQueue(new int[] { 2, 4, 9, 10, 17 });
            Queue<int> q18 = ArrToQueue(new int[] { 1, 4, 4, 1, 5, -9, 1, -9, -9 });


            Console.WriteLine("\n 3" + " " + q2);
            Console.WriteLine("3:CountNum " + CountNum(q2, 5));

            Console.WriteLine("\n 4" + " " + q2);
            Console.WriteLine("4:RemoveNum " + RemoveNum(q2, 8));
            Console.WriteLine("after 4" + q2);
            Console.WriteLine("===============");

            Console.WriteLine("\n 5"+ " " + q2);
            Console.WriteLine("5:CountAndRemove " + CountAndRemove(q2, 5));
            Console.WriteLine("after 5" + q2);
            Console.WriteLine("===============");

            Console.WriteLine("\n 6" + " " + q3);
            Console.WriteLine("6:GetLast " + GetLast(q3));
            Console.WriteLine("after 6 " + q3);
            Console.WriteLine("===============");

            Console.WriteLine("\n7 " + q4);
            Console.WriteLine("7:isPalindrom " + IsPalindrom(q4));
            Console.WriteLine("after 7 " + q4);
            Console.WriteLine("===============");

            Console.WriteLine("\n8 " + q5);
            RemoveDuplicate(q5);
            Console.WriteLine("8. after RemoveDuplicate(q5) " + q5);
            Console.WriteLine("============================");

            Console.WriteLine("\n9 " + q6);
            Queue<int> q7 = DifferentialQ(q6);
            Console.WriteLine("9. new queue - differentialsQueue(q7) " + q7);
            Console.WriteLine("after differentialsQueue(q6) " + q6);
            Console.WriteLine("============================");

            Console.WriteLine("\n11 " + q10);
            Queue<int> q11 = SplitQueue(q10, 10);
            Console.WriteLine("11. new queue - SplitQueue(q,10) " + q11);
            Console.WriteLine("after SplitQueue " + q10);
            Console.WriteLine("============================");

            Console.WriteLine("\n12 " + q12);
            Console.WriteLine("ProtectionQ ? " + ProtectionQ(q12, "Yakov"));
            Console.WriteLine("12. after ProtectionQ(q12) " + q12);
            Console.WriteLine("============================");

            Console.WriteLine(q13);
            Console.WriteLine(" 13 .  after ");
            Console.WriteLine(Rezef(q13));
            Console.WriteLine("=========================");

            Console.WriteLine("\n14   Is Queue sorted ");
            Console.WriteLine(q141 + "  " + IsSort(q141));
            Console.WriteLine(q142 + "  " + IsSort(q142));
            Console.WriteLine("=========================");

            Console.WriteLine("\n15   Add to sort queue");
            Console.WriteLine(q15 + "   add 7  ,add  1,  add  11  ");
            AddToSort(q15, 7);
            AddToSort(q15, 1);
            AddToSort(q15, 11);
            Console.WriteLine(q15);
            Console.WriteLine("=========================");

            Console.WriteLine("\n16   CommonNumberse");
            Console.WriteLine(q161 + " " + q162);
            Console.WriteLine("CommonNumberse " + CommonNumberse(q161, q162));
            Console.WriteLine("=========================");

            Console.WriteLine("\n17   Merage queue");
            Console.WriteLine(q171 + " " + q172);
            Console.WriteLine("Merage   " + Merage(q171, q172));
            Console.WriteLine("=========================");

            Console.WriteLine("\n18   Incidence queue");
            Console.WriteLine("to Queue " + q18);
            Console.WriteLine("Incidence queue" + Incidence(q18));
            Console.WriteLine("=========================");

            Console.ReadLine();
        }
    }
}
