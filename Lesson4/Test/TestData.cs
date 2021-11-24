using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4.Test
{
    public class TestData
    {
        /*public int ProductID { get; set; }
        public Guid Article { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
        public DateTime DateExpired { get; set; }
        public bool IsMedical { get; set; }
        public int TemperatureKeepFrom { get; set; }
        public int TemperatureKeepTo { get; set; }*/
        private  string _product;
        private string _productNew;
        public TestData()
        {
            Product =    @"[{'ProductID':'1','Article':'1000','Name':'Box' ,'Notification':'Very Large Box With AnyThing','Weight':'23.45','Long':'10.28','Height':'25.78','Width':'5.50','Price':'6500.50','DateMade':'2019-12-19T14:10:31','Count':'555'}]";
            ProductNew = @"[{'ProductID':'999','Article':'9cd74d10-d7be-4630-ad6b-d0a2e6913d8e','Name':'Aspirin Tabletes','Cost':'85.68','Count':'20','DateExpired':'2025-01-01T00:00:00','IsMedical':'true','TemperatureKeepFrom':'2','TemperatureKeepto':'25'}]";
        }

        public  string Product {
            get 
            {
                return _product;
            }
            private set 
            {
                _product = value;
            }
        }

        public string ProductNew
        {
            get
            {
                return _productNew;
            }
            private set
            {
                _productNew = value;
            }
        }
    }
}
