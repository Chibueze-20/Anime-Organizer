//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnimeOrganizer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AnimeRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string title { get; set; }
        public int numberOfEpisodes { get; set; }
        public Nullable<int> rating { get; set; }
        private string description { get; set; }
        public System.DateTimeOffset lastUpdate { get; set; }
        private Nullable<int> year { get; set; }
        private string season { get; set; }
    }
}