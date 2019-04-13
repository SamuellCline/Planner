using System;
using System.ComponentModel.DataAnnotations;


namespace Planner.Models
{
    public class Plan
    {
        public int Id { get; set; }
        
        
       


        [DataType(DataType.Date),Required]
        public DateTime Date { get; set; }
        
        public string Theme { get; set; }
        [Display(Name = "Opening Hymn"), Range(1, 341), Required]

        public int OpeningSong { get; set; }
        [Display(Name = "Invocation"), Required]
        public string OpeningPrayer { get; set; }
       

        public string Conducting { get; set; }
        [Display(Name = "Sacrament Hymn"), Range(169, 197), Required]
        public int SacramentHymn { get; set; }

        [Display(Name = "Talk 1"), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(50), Required]
        public string Speaker1 { get; set; }
        [Display(Name = "Topic"), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(50), Required]
        public string TalkTopic1 { get; set; }
        [Display(Name = "Talk 2"), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(50)]
        public string Speaker2 { get; set; }
        [Display(Name = "Topic"), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(50)]
        public string TalkTopic2 { get; set; }
        [Display(Name ="Closing Hymn"),Range(1,341), Required]
        public int ClosingSong { get; set; }
        [Display(Name = "Benediction"),RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(50), Required]
        public string ClosingPrayer { get; set; }

    }
}