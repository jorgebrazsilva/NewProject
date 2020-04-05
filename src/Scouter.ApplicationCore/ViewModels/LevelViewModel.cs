using Scouter.ApplicationCore.ViewModels.Bases;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scouter.ApplicationCore.ViewModels
{
    public class LevelViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string LevelName { get; set; }
        public string LevelNameNote { get; set; }        
    }
}

