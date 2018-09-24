using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://www.youtube.com/watch?v=zmdWWujU8M4

namespace InversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {

            //user user = new user(1); This is the code which is tightly coupled to the user class

            // Here the data access layer is now inverted, initiall we were creating it in the user now its been swithced and something else will tell the user what Data access layer to use.
            // User class no longer creates a data access layer instead it relies on something else to tell what  data access layer to use.
            user user = new user(new MySqlDAL());
            user.Add();
            }
    }



    class user
    {
        IDal dal;
        //This is the code which is tightly coupled to the user class
        // If DAL type is passed throught the constructor
        //public user(int IdalType)
        //{
        //   
        //if (IdalType ==1 )
        //{
        //    dal = new MySqlDAL();
        //}
        //else
        //{
        //    dal = new SQLServerDal();

        //}
        //}

        public user( IDal dalltype)
        {
            dal = dalltype;   // This is where we inverted the control
        }
           


        public bool IsValid
        {
            get { return true; }
        }
        
        public void Add()
        {
            if (IsValid)
            {
                dal.Add(this);
            }
        }
    }



    interface IDal
    {
        void Add(user user);
    }


    class MySqlDAL :IDal
    {
        public void Add( user user)
        {
            // Do nothing
        }
    }


    class SQLServerDal : IDal
    {
        public void Add(user user)
        {
            // Do nothing
        }
    }
}
