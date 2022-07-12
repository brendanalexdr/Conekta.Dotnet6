﻿namespace Conekta.Dotnet6.Models
{
    public class PaymentMethod
    {
        public string type { get; set; }
        public string name { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string auth_code { get; set; }
        public string last4 { get; set; }
        public string brand { get; set; }
        public string issuer { get; set; }
        public string account_type { get; set; }
        public string country { get; set; }
        public string service_name { get; set; }
        public int expires_at { get; set; }
        public string store_name { get; set; }
        public string reference { get; set; }
        public string payment_source_id { get; set; }
        public string barcode_url { get; set; }
        public string @object { get; set; }
        public string clabe { get; set; }
        public string bank { get; set; }
        public string receiving_account_number { get; set; }


    }
}
