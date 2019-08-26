using System.Collections.Generic;
namespace TinTucCTSV.Models.Form
{
    public class FormIndexModel
    {
        public IEnumerable<FormViewModel> listForms {get;set;}
        public string SearchQuery { get; set; }
    }
}