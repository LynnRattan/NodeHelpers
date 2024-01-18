using NodeClass;
using NodeInserts.Models;

namespace NodeInserts
{
    internal class Program
    {
        public static bool ShabatExists(Node<ShabatRecievers> shabatot, int day, int month, int year)
        {
            while(shabatot!=null)
            {
                if(shabatot.GetValue().GetDay()==day && shabatot.GetValue().GetMonth()==month && shabatot.GetValue().GetYear()==year)
                    return true;
            }
            return false;
        }

        public static Node<ShabatRecievers> DeleteShabat(string name, Node<ShabatRecievers> shabatot)
        {
            Node<ShabatRecievers> head = shabatot;
            if (shabatot.GetValue().GetParent1()==name || shabatot.GetValue().GetParent2() == name)
            {
                head = shabatot.GetNext();
                shabatot.SetNext(null);
                return head;
            }
            while(shabatot != null && shabatot.HasNext()) 
            {
                Node<ShabatRecievers> next = shabatot.GetNext();
                if (next.GetValue().GetParent1() == name || next.GetValue().GetParent2() == name)
                {
                   
                    shabatot.SetNext(next.GetNext());
                    next.SetNext(null);
                }
            }
            return head;
        }
        static void Main(string[] args)
        {
            Node<ShabatRecievers> shabatShalom = new Node<ShabatRecievers>(new ShabatRecievers("Shiri","Shira",18,1,2024));
            Node<ShabatRecievers> nextShabat = new Node<ShabatRecievers>(new ShabatRecievers("Ofek", "Aviv", 25, 1, 2024));
            shabatShalom.SetNext(nextShabat);

            ShabatRecievers sh = shabatShalom.GetValue();
            string p1 = sh.GetParent1();


        }
    }
}