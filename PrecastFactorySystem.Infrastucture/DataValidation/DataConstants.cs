﻿namespace PrecastFactorySystem.Infrastructure.DataValidation
{
    public static class DataConstants
    {
        //Precast
        public const int PrecastNameMinLength = 3;

        public const int PrecastNameMaxLength = 30;

        public const int PrecastCountMinValue = 1;

        public const int PrecastCountMaxValue = 1000;

        public const string ConcreteAmountMinValue = "0";

        public const string ConcreteAmountMaxValue = "50";

        public const string ReinforceAmountMinValue = "0";

        public const string ReinforceAmountMaxValue = "10000";

        //PrecastType
        public const int PrecastTypeNameMinLength = 5;

        public const int PrecastTypeNameMaxLength = 30;

        //ConcreteClass
        public const int ConcreteClassNameMinLength = 6;

        public const int ConcreteClassNameMaxLength = 20;

        //Reinforce
        public const int ReinforcePositionMinLength = 1;
                         
        public const int ReinforcePositionMaxLength = 20;


		public const int ReinforceCountMinValue = 1;

		public const int ReinforceCountMaxValue = 500;

		public const string ReinforceLengthMinValue = "0";

        public const string ReinforceLengthMaxValue = "14";


        //Project
        public const int ProjectNameMinLength = 2;

        public const int ProjectNameMaxLength = 100;

        public const int ProjectNumberMinLength = 3;

        public const int ProjectNumberMaxLength = 10;

        //Department
        public const int DepartmentNameMinLength = 5;

        public const int DepartmentNameMaxLength = 20;

        //Deliverer
        public const int DelivererNameMinLength = 3;

        public const int DelivererNameMaxLength = 30;

        public const int DelivererEmailMinLength = 5;

        public const int DelivererEmailMaxLength = 60;


        //Common
        public const int CountMinValue = 0;

        public const string DateFormat = "dd.MM.yyyy";

        //User
        public const int UserNameMinLength = 3;

        public const int UserNameMaxLength = 20;

        public const int UserPasswordMinLength = 6;

        public const int UserPasswordMaxLength = 20;

        public const int UserEmailMinLength = 5;

        public const int UserEmailMaxLength = 60;
    }
}