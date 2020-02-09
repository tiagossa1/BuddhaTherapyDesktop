using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyManagementSystem.Common
{
    public static class Constants
    {
        public static string DatabasePath { get; } = "C:/TMS/database.db";
        public static string AdminPasswordPath { get; } = "C:/TMS/administratorPassword.txt";

        public enum Gender
        {
            Male,
            Female
        }
    }
}
