//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestDatabase.Geography.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utente
    {
        public string IdUtente { get; set; }
        public string fk_AspNetUsers_Id { get; set; }
        public string DescUtente { get; set; }
        public string NomeUtente { get; set; }
        public string CognomeUtente { get; set; }
        public Nullable<System.DateTime> DataInserimento { get; set; }
        public Nullable<System.DateTime> DataAggiornamento { get; set; }
        public Nullable<System.DateTime> DataCessato { get; set; }
    }
}