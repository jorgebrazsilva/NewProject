using System.ComponentModel.DataAnnotations;

using Scouter.ApplicationCore.ViewModels.Bases;
namespace Scouter.ApplicationCore.ViewModels
{
    public class PositionViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string PositionNameNote { get; set; }
    }
}

