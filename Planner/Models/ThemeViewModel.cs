using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System;


namespace Planner.Models
{
    public class ThemeViewModel
    {
        public List<Plan> Plans;
        public SelectList Themes;
        public string Theme { get; set; }
        public string SearchString { get; set; }

       
    }
}