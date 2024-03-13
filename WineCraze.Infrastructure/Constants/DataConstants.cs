using Microsoft.VisualBasic;

namespace WineCraze.Infrastructure.Constants
{
    public static class DataConstants
    {
        // Customer

        public const int NameCustomerMaxLength = 50;
        public const int EmailMaxLength = 100;
        public const int AddressMaxLength = 200;
        public const int PhoneMaxLength = 15;

        //Report

        public const int TitleMaxLength = 50;
        public const int DescriptionMaxLength = 500;

        //Sale

        //public const DateFormat  "dd/MM/yyyy HH:mm";

        //Supplier

        public const int NameSupplierMaxLength = 100;
        public const int ContactPersonSupplierMaxLength = 100;


        //Wine
        public const int WineMaxLength = 40;
        public const int CountryMaxLength = 50;
        public const int RegionMaxLength = 50;

        public const string PriceMin = "0.00";

        public const string PriceMax = "2000.00";

    }
}
