using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Intex.Models;

namespace Intex.DAL
{
    public class IntexContext : DbContext
    {
        public IntexContext() : base("IntexContext")
        {

        }

        public DbSet<Assay> Assays { get; set; }
        public DbSet<Assay_Test> Assay_Tests { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<Compound_Receipt_Log_Entry> Compound_Receipt_Log_Entries { get; set; }
        public DbSet<Compound_Weighing_and_Dispensing_Log_Entry> Compound_Weighing_and_Dispensing_Log_Entries { get; set; }
        public DbSet<Credit_Card_Payment> Credit_Card_Payments { get; set; }
        public DbSet<Data_Report> Data_Reports { get; set; }
        public DbSet<Deposit_Slip> Deposit_Slips { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee_Type> Employee_Types { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoice_Details> Invoice_Detail { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Material_Test> Material_Tests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Progress> Order_Progresses { get; set; }
        public DbSet<Payment_Type> Payment_Types { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test_Result> Test_Results { get; set; }
        public DbSet<Test_Tube> Test_Tubes { get; set; }
    }
}