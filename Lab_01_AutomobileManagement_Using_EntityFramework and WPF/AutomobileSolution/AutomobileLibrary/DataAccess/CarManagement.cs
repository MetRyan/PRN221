using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarManagement
    {
        //-- Using Singleton Pattern
        private static CarManagement instance = null;
        public static readonly object instanceLock = new object();
        private CarManagement() { }

        public static CarManagement Instance
        {

            get
            {
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {

                            instance = new CarManagement();
                        }
                        return instance;

                    }
                }

            }
        }
    }
